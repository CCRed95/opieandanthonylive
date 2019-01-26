import Vue from 'vue';
import Vuex from 'vuex';

import * as audio from './audio';
import * as auth from './auth';
import { ui } from './ui';
import { error } from './error';

Vue.use(Vuex);

export interface Metadata {
  artwork: string;
  title: string;
  show: string;
}

const tracks: Array<audio.Track<Metadata>> = [
  {
    url: 'https://archive.org/download/OA-2008-12/O&A-2008-12-04.mp3',
    metadata: {
      artwork: 'http://opieandanthonylive.info/alpha3/images/Ralphie%20May.jpg',
      title: 'December 4, 2008 - Bill Burr, Ralphie May',
      show: 'Opie and Anthony',
    },
  },
  {
    url: 'https://archive.org/download/OA-2008-12/O&A-2008-12-05.mp3',
    metadata: {
      artwork: 'http://opieandanthonylive.info/alpha3/images/Bill%20Burr.jpg',
      title: 'December 5, 2008 - Bill Burr, Joe DeRosa',
      show: 'Opie and Anthony',
    },
  },
  {
    url: 'https://archive.org/download/OA-2008-12/O&A-2008-12-12.mp3',
    metadata: {
      artwork: 'http://opieandanthonylive.info/alpha3/images/Jeffrey%20Ross.jpg',
      title: 'December 12, 2008 - Bob Kelly, Jeffrey Ross, DL Hughley',
      show: 'Opie and Anthony',
    },
  },
];

export const store = new Vuex.Store({
  modules: {
    auth: auth.createModule(auth.loadState()),
    error,
    ui,
  },

  plugins: [
    audio.mkPlugin(new Audio(), 'audio', tracks),
  ],
});
