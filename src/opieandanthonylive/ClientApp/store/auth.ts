import { Module } from 'vuex';

import { Auth, RootState } from './types';

export const auth: Module<Auth, RootState> = {

  namespaced: true,

  state: {
    kind: 'signed-out',
  },

  getters: {
    isSignedIn: s => s.kind === 'signed-in',
  }

};