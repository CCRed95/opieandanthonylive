import { Module, ActionContext } from 'vuex';

import { RootState } from "./types";

type PlaybackStatus = 'paused' | 'playing';

export interface Track {
  title:    string;
  author:   string;

  url:      string;
  badgeUrl: string;
}

interface EmptyPlaylist {
  kind: 'empty';
}

interface InitializedPlaylist {
  kind: 'initialized';
  current: number;
  tracks: Track[];
}

type Playlist = EmptyPlaylist | InitializedPlaylist;

interface State {
  playback: PlaybackStatus;
  elapsed?: number;
  playlist: Playlist;
}

export const initialState: State = {
  playback: 'paused',
  playlist: {
    kind: 'initialized',
    current: 0,
    tracks: [
      {
        title: "track1",
        author: "O&A",
        url: "https://archive.org/download/OA-2008-12/O&A-2008-12-04.mp3",
        badgeUrl: "http://opieandanthonylive.info/alpha3/images/Ralphie%20May.jpg"
      },
      {
        title: "track2",
        author: "O&A",
        url: "https://archive.org/download/OA-2008-12/O&A-2008-12-05.mp3",
        badgeUrl: "http://opieandanthonylive.info/alpha3/images/Bill%20Burr.jpg"
      },
      {
        title: "track3",
        author: "O&A",
        url: "https://archive.org/download/OA-2008-12/O&A-2008-12-12.mp3",
        badgeUrl: "http://opieandanthonylive.info/alpha3/images/Jeffrey%20Ross.jpg"
      },
    ]
  }
};

const audio = new Audio();

const getters = {

  isPlaying: (s: State) => 
    s.playback == 'playing',

  currentTrack: (s: State) =>
    s.playlist.kind == 'initialized'
      ? s.playlist.tracks[s.playlist.current]
      : null,

};

const mutations = {

  play: (s: State) => {
    s.playback = 'playing';
  },

  pause: (s: State) => {
    audio.pause();
    s.playback = 'paused';
  }
}

const actions = {

  play: (ctx: ActionContext<State, RootState>) => {
    const s = ctx.state;

    if (s.playback == 'playing' || s.playlist.kind == 'empty')
      return;

    const src = s.playlist.tracks[s.playlist.current].url;
    if (audio.src != src)
      audio.src = src;

    audio.play()
      .then(() => ctx.commit('play'))
      .catch((x: any) => alert(JSON.stringify(x)));

  },

};

export const createModule = (state: State): Module<State, RootState> => ({
  namespaced: true,
  state,
  getters,
  mutations,
  actions,
});
