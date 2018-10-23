import { ActionContext, Store } from 'vuex';

import { RootState } from "./types";
import { max, min } from '../helpers';

interface Track<M> {
  url: string;
  metadata: M;
};

type PlaybackStatus = 'paused' | 'loading' | 'playing';

interface Playlist<M> {
  current: number;
  tracks: Track<M>[];
};

interface State<M> {
  status: PlaybackStatus;
  elapsed?: number;
  duration?: number;
  playlist: Playlist<M>;
};

const mkGetters = <M>() => ({

  isPlaying: (s: State<M>) =>
    s.status == 'playing',

  isLoading: (s: State<M>) =>
    s.status == 'loading',

  currentTrack: (s: State<M>) =>
    s.playlist.tracks[s.playlist.current],

});

const mkMutations = <M>() => ({

  status: (s: State<M>, status: PlaybackStatus) =>
    s.status = status,

  elapsed: (s: State<M>, elapsed: number) =>
    s.elapsed = elapsed,

  duration: (s: State<M>, duration: number) =>
    s.duration = duration,

  prev: (s: State<M>) =>
    s.playlist.current = max(s.playlist.current - 1, 0),

  next: (s: State<M>) =>
    s.playlist.current = min(s.playlist.current + 1, s.playlist.tracks.length),

  add: (s: State<M>, track: Track<M>) =>
    s.playlist.tracks.push(track),

});

const mkActions = <M>(audio: HTMLAudioElement) => ({

  pause: (ctx:ActionContext<State<M>, RootState>) => 
    audio.pause(),

  stop: (ctx:ActionContext<State<M>, RootState>) => {
    audio.pause();
    audio.currentTime = 0;
  },

  play: (ctx:ActionContext<State<M>, RootState>) => {
    const state = ctx.state;

    // Reaching the end of the playlist, we should stop.
    if (!(state.playlist.current in state.playlist.tracks)) {
      ctx.dispatch('stop');
      return;
    }

    // Updating audio.src disrupts playback.  Only do so if we're supposed to
    // be playing something else.
    const current: Track<M> = ctx.getters.currentTrack;
    if (audio.src != current.url)
      audio.src = current.url;

    // This *should* be a no-op if we're in the middle of playing the track.
    audio.play()
      .catch((x: string | null) => {
        if (x == null) {
          // This only ever seems to occur when the `play()` action is
          // disrupted, for example by changing `audio.src`.  As best as I can
          // tell, ignoring this error is harmless.
          return;
        } else {
          // TOOD: Better error reporting facilities.
          alert(x);
        }
      });
  },

});

export const mkPlugin = <M>(audio: HTMLAudioElement, moduleName = 'audio') => <S>(s: Store<S>) => {
  s.registerModule(moduleName, {
    namespaced: true,
    state: {
      status: 'paused', playlist: {
        current: 0,
        tracks: [
          { url: "https://archive.org/download/OA-2008-12/O&A-2008-12-04.mp3", metadata: {} as M },
          { url: "https://archive.org/download/OA-2008-12/O&A-2008-12-05.mp3", metadata: {} as M },
          { url: "https://archive.org/download/OA-2008-12/O&A-2008-12-12.mp3", metadata: {} as M },
        ]
      }
    },
    getters: mkGetters<M>(),
    mutations: mkMutations<M>(),
    actions: mkActions<M>(audio),
  });

  audio.addEventListener('playing', () => s.commit(`${moduleName}/status`, 'playing'));
  audio.addEventListener('pause',   () => s.commit(`${moduleName}/status`, 'pause'));
  audio.addEventListener('stalled', () => s.commit(`${moduleName}/status`, 'loading'));
  audio.addEventListener('waiting', () => s.commit(`${moduleName}/status`, 'loading'));

  audio.addEventListener('durationchange', () => s.commit(`${moduleName}/duration`, audio.duration));
  audio.addEventListener('timeupdate',     () => s.commit(`${moduleName}/elapsed`, audio.currentTime));
};