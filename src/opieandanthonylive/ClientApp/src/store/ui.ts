import { Module } from 'vuex';
import { RootState } from './types';

interface State {
}

const getters = {
  shouldShowFooter: (s:  State, gs: any, rs: any) => {
    return rs.route.path !== '/player';
  },
};

export const ui: Module<State, RootState> = {
  namespaced: true,
  getters,
};
