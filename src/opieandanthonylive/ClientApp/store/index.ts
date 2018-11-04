import Vue  from 'vue';
import Vuex, { Store } from 'vuex';

import { RootState } from './types';
import * as auth from './auth';
import * as audio from './audio';

Vue.use(Vuex);

export interface Metadata {
  artwork: string;
  title: string;
  show: string;
}

export const store: Store<RootState> = new Vuex.Store({

  modules: {
    auth: auth.createModule(auth.loadState()),
  },

  plugins: [
    audio.mkPlugin<Metadata>(new Audio())
  ],

});