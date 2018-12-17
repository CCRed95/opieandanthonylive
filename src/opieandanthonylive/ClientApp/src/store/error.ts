import { Module } from 'vuex';
import { RootState } from './types';

interface State {
  count: number;
  error: null | string;
}

const state = {
  count: 0,
  error: null,
};

const mutations = {
  error: (s: State, msg: string) => { s.count++; s.error = msg; },
};

export const error: Module<State, RootState> = {
  namespaced: true,
  state,
  mutations,
};
