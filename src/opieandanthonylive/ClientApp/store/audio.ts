import { ActionContext, Store } from 'vuex';

import { RootState } from "./types";
import { max, clamp } from '../helpers';

interface Track<M> {
  url: string;
  metadata: M;
};

interface Playlist<M> {
  index: number;
  tracks: Track<M>[];
};

type PlaybackStatus = 'paused' | 'loading' | 'playing';

interface State<M> {
  status:   PlaybackStatus;
  elapsed:  number;
  duration: number;
  volume:   number;
  playlist: Playlist<M>;
};

const mkGetters = <M>() => ({

  isPlaying: (s: State<M>) => s.status == 'playing',
  isLoading: (s: State<M>) => s.status == 'loading',
  isEmpty:   (s: State<M>) => s.playlist.tracks.length == 0,

  currentTrack: (s: State<M>) =>
    s.playlist.tracks.length == 0
      ? undefined
      : s.playlist.tracks[s.playlist.index],

});

const mkMutations = <M>() => ({

  status: (s: State<M>, status: PlaybackStatus) =>
    s.status = status,

  elapsed: (s: State<M>, elapsed: number) =>
    s.elapsed = elapsed,

  duration: (s: State<M>, duration: number) =>
    s.duration = duration,

  prev: (s: State<M>) =>
    s.playlist.index = max(0, s.playlist.index - 1),

  next: (s: State<M>) =>
    s.playlist.index = (s.playlist.index + 1) % s.playlist.tracks.length,

  add: (s: State<M>, t: Track<M>) =>
    s.playlist.tracks.push(t),

  volume: (s: State<M>, v: number) =>
    s.volume = v,

});

const mkActions = <M>(audio: HTMLAudioElement) => ({

  volume: (ctx:ActionContext<State<M>, RootState>, v: number) => {
    ctx.commit('volume', v);
    audio.volume = clamp(0, v, 1);
  },

  pause: (ctx:ActionContext<State<M>, RootState>) => 
    audio.pause(),

  seek: (ctx:ActionContext<State<M>, RootState>, time: number) => {
    audio.currentTime = time;
    ctx.commit('elapsed', time);
  },

  play: async (ctx:ActionContext<State<M>, RootState>) => {
    if (ctx.state.playlist.tracks.length == 0)
      return;

    try {
      await audio.play();
    }
    catch (e) {
      if (e.code == e.ABORT_ERR) {
        // This only ever seems to occur when the `play()` action is
        // disrupted, for example by changing `audio.src`.  As best as I can
        // tell, ignoring this error is harmless.
        return;
      }
      else {
        // TOOD: Better error reporting capabilities.
        alert(e);
      }
    }
  },

  prev: async (ctx:ActionContext<State<M>, RootState>) => {
    const playlist = ctx.state.playlist;

    if (playlist.tracks.length == 0)
      return;

    if (playlist.index == 0 || audio.currentTime >= 3) {
      audio.currentTime = 0;
    } else {
      ctx.commit('prev');
      audio.src = playlist.tracks[playlist.index].url;
      await ctx.dispatch('play');
    }
  },

  next: async (ctx:ActionContext<State<M>, RootState>) => {
    const playlist = ctx.state.playlist;
    if (playlist.tracks.length == 0)
      return;

    ctx.commit('next');
    audio.src = playlist.tracks[playlist.index].url;

    if (playlist.index > 0)
      await ctx.dispatch('play');
  },

  add: (ctx:ActionContext<State<M>, RootState>, t: Track<M>) => {
    if (ctx.state.playlist.tracks.length == 0)
      audio.src = t.url;

    ctx.commit('add', t)
  },

});

export const mkPlugin = <M>(audio: HTMLAudioElement, moduleName = 'audio') => <S>(s: Store<S>) => {

  const state: State<M> = {
    status: 'paused',
    elapsed: audio.currentTime,
    duration: audio.duration,
    volume: audio.volume,
    playlist: { index: 0, tracks: [] },
  };

  s.registerModule(moduleName, {
    namespaced: true,
    state,
    getters: mkGetters<M>(),
    mutations: mkMutations<M>(),
    actions: mkActions<M>(audio),
  });

  audio.addEventListener('pause',   () => s.commit(`${moduleName}/status`, 'pause'));
  audio.addEventListener('playing', () => s.commit(`${moduleName}/status`, 'playing'));
  audio.addEventListener('waiting', () => s.commit(`${moduleName}/status`, 'loading'));

  audio.addEventListener('durationchange', () => s.commit(`${moduleName}/duration`, audio.duration));
  audio.addEventListener('timeupdate',     () => s.commit(`${moduleName}/elapsed`, audio.currentTime));

  // TODO: Obviously this needs to be removed, but there's another reason that
  // isn't immediately obvious for that.  `.dispatch` returns a Promise.
  // Wherever this actually gets called from eventually would similarly need to
  // `await` that.
  s.dispatch(`${moduleName}/add`, { url: 'https://archive.org/download/OA-2008-12/O&A-2008-12-04.mp3', metadata: {} as M });
  s.dispatch(`${moduleName}/add`, { url: 'https://archive.org/download/OA-2008-12/O&A-2008-12-05.mp3', metadata: {} as M });
  s.dispatch(`${moduleName}/add`, { url: 'https://archive.org/download/OA-2008-12/O&A-2008-12-12.mp3', metadata: {} as M });

};