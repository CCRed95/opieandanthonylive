import { ActionContext, Store } from 'vuex';

import { RootState } from './types';
import { clamp, max, randomInt } from '../util';

export interface Track<M> {
  url: string;
  metadata: M;
}

interface Playlist<M> {
  index: number;
  tracks: Array<Track<M>>;
}

type PlaybackStatus = 'paused' | 'loading' | 'playing';

interface State<M> {
  status: PlaybackStatus;
  elapsed: number;
  duration: number;
  muted: boolean;
  volume: number;
  playlist: Playlist<M>;
  repeat: boolean;
  shuffle: boolean;
}

const mkGetters = <M>() => ({

  isPlaying: (s: State<M>) => s.status === 'playing',
  isLoading: (s: State<M>) => s.status === 'loading',
  isEmpty:   (s: State<M>) => s.playlist.tracks.length === 0,
  isMuted:   (s: State<M>) => s.muted,
  volume:    (s: State<M>) => s.muted ? 0 : s.volume,

  currentTrack: (s: State<M>) =>
    s.playlist.tracks.length === 0
      ? undefined
      : s.playlist.tracks[s.playlist.index],

});

const mkMutations = <M>() => ({

  status:   (s: State<M>, status: PlaybackStatus) => s.status = status,
  elapsed:  (s: State<M>, elapsed: number)        => s.elapsed = elapsed,
  duration: (s: State<M>, duration: number)       => s.duration = duration,
  muted:    (s: State<M>, b: boolean)             => s.muted = b,
  volume:   (s: State<M>, v: number)              => s.volume = v,
  repeat:   (s: State<M>, v: boolean)             => s.repeat = v,
  shuffle:  (s: State<M>, v: boolean)             => s.shuffle = v,

  prev: (s: State<M>) =>
    s.playlist.index = max(0, s.playlist.index - 1),

  currentTrack: (s: State<M>, v: number) =>
    s.playlist.index = v % s.playlist.tracks.length,

  add: (s: State<M>, t: Track<M>) =>
    s.playlist.tracks.push(t),

});

const mkActions = <M>(audio: HTMLAudioElement) => ({

  muted: (ctx: ActionContext<State<M>, RootState>, b: boolean) => {
    ctx.commit('muted', b);
    audio.muted = b;
  },

  toggleMute: async (ctx: ActionContext<State<M>, RootState>) =>
    await ctx.dispatch('muted', !ctx.state.muted),

  volume: async (ctx: ActionContext<State<M>, RootState>, v: number) => {
    const value = clamp(0, v, 1);
    if (value === 0) {
      await ctx.dispatch('muted', true);
    } else {
      ctx.commit('volume', value);
      audio.volume = value;
      await ctx.dispatch('muted', false);
    }
  },

  pause: () =>
    audio.pause(),

  seek: (ctx: ActionContext<State<M>, RootState>, time: number) => {
    audio.currentTime = time;
    ctx.commit('elapsed', time);
  },

  play: async (ctx: ActionContext<State<M>, RootState>) => {
    if (ctx.state.playlist.tracks.length === 0) {
      return;
    }

    await audio.play();
  },

  prev: async (ctx: ActionContext<State<M>, RootState>) => {
    const playlist = ctx.state.playlist;

    if (playlist.tracks.length === 0) {
      return;
    }

    if (playlist.index === 0 || audio.currentTime >= 3) {
      audio.currentTime = 0;
    } else {
      ctx.commit('prev');
      audio.src = playlist.tracks[playlist.index].url;
      await ctx.dispatch('play');
    }
  },

  currentTrack: async (ctx: ActionContext<State<M>, RootState>, v: number) => {
    ctx.commit('currentTrack', v);
    audio.src = ctx.state.playlist.tracks[ctx.state.playlist.index].url;
  },

  next: async (ctx: ActionContext<State<M>, RootState>) => {
    const playlist = ctx.state.playlist;
    if (playlist.tracks.length === 0) {
      return;
    }

    /* -1 used as a sentinel to stop playback. */
    const minTrack = ctx.state.repeat ? 0 : -1;

    const nextTrack = ctx.state.shuffle
      ? randomInt(minTrack, playlist.tracks.length)
      : (playlist.index + 1) % playlist.tracks.length;

    await ctx.dispatch('currentTrack', max(nextTrack, 0));

    const shouldPlay
      = ctx.state.repeat                      // always on repeat, OR -
     || ctx.state.shuffle && nextTrack !== -1 // if shuffling and sentinel isn't chosen, OR -
     || nextTrack > 0;                        // we haven't wrapped around from the end.

    if (shouldPlay) {
      await ctx.dispatch('seek', 0);
      await ctx.dispatch('play');
    } else {
      await ctx.dispatch('pause');
      await ctx.dispatch('seek', 0);
    }
  },

  add: (ctx: ActionContext<State<M>, RootState>, t: Track<M>) => {
    if (ctx.state.playlist.tracks.length === 0) {
      audio.src = t.url;
    }

    ctx.commit('add', t);
  },

});

export const mkPlugin = <M>(
  audio: HTMLAudioElement,
  moduleName = 'audio',
  tracks: Array<Track<M>> = [],
) => <S>(s: Store<S>) => {

  const state: State<M> = {
    status:   'paused',
    elapsed:  audio.currentTime,
    duration: audio.duration,
    muted:    audio.muted,
    volume:   audio.volume,
    playlist: { index: 0, tracks: [] },
    repeat:   false,
    shuffle:  false,
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

  audio.addEventListener('ended', () => s.dispatch(`${moduleName}/next`));

  for (const t of tracks) {
    s.dispatch(`${moduleName}/add`, t);
  }

};
