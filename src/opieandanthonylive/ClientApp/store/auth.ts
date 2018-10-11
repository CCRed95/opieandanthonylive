import { Module } from 'vuex';
import axios from 'axios';

import { RootState } from './types';

export type LoginPayload = {
  username: string;
  password: string;
}

export type RegisterPayload = {
  email:    string;
  username: string;
  password: string;
}

type LoginMutationPayload = {
  username: string;
  token:    string;
}

interface SignedOut {
  kind: 'signed-out';
};

interface SignedIn {
  kind: 'signed-in';
  username: string;
};

type State = {
  authState: SignedOut | SignedIn;
}

export const auth: Module<State, RootState> = {

  namespaced: true,

  state: {
    authState: {
      kind: 'signed-out',
    }
  },

  getters: {
    isSignedIn: s => s.authState.kind === 'signed-in',
  },

  mutations: {
    login: (s: State, payload: LoginMutationPayload) => {

      // store the token
      localStorage.setItem('auth-token', payload.token);

      s.authState = {
        kind: "signed-in",
        username: payload.username
      };
    },
  },

  actions: {

    login: (ctx, payload: LoginPayload) => axios
      .post('http://localhost:5000/api/auth/login', payload)
      .then(x => ctx.commit('login', {
        username: payload.username,
        token: x.data
      }))
      .catch(x => alert(x)),

    register: (ctx, payload: RegisterPayload) => axios
      .post('http://localhost:5000/api/auth/register', payload)
      .then(_ => ctx.dispatch('login', {
        username: payload.username,
        password: payload.password
      }))
      .catch(x => alert(x)),

  }

};