import { Module, ActionContext } from 'vuex';
import axios, { AxiosError } from 'axios';

import { RootState } from './types';
import { decodeJwt } from '../helpers';

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
  token: string;
};

type AuthState = SignedOut | SignedIn;

type State = {
  authState: AuthState;
}

export const loadState = (): State => {
  const token = localStorage.getItem('auth-token');
  return token == null
    ? { authState: { kind: 'signed-out' } }
    : { authState: { kind: 'signed-in', token } };
}

const getters = {

  isSignedIn: (s: State) =>
    s.authState.kind == 'signed-in',

  username: (s: State) =>
    s.authState.kind == 'signed-in'
      ? decodeJwt(s.authState.token).sub
      : null,

};

const AUTH_TOKEN = 'auth-token';

const mutations = {

  login: (s: State, payload: LoginMutationPayload) => {
    localStorage.setItem(AUTH_TOKEN, payload.token);
    s.authState = { kind: 'signed-in', token: payload.token };
  },

  signOut: (s: State) => {
    localStorage.removeItem(AUTH_TOKEN);
    s.authState = { kind: 'signed-out' };
  }

};

interface UsernameAlreadyExists {
  kind: 'username-already-exists';
  username: string;
}

interface LoginFailure {
  kind: 'login-error';
}

interface OtherError {
  kind: 'other-error';
  error: AxiosError;
}

export type LoginError = LoginFailure | OtherError;
export type RegistrationError = UsernameAlreadyExists | LoginError;

const actions = {

  login: (ctx: ActionContext<State, RootState>, payload: LoginPayload) => axios
    .post('/api/auth/login', payload)
    .then(x => ctx.commit('login', {
      username: payload.username,
      token: x.data
    }))
    .catch((x: AxiosError) => {
      throw (x.response && 'login_failure' in x.response.data)
        ? { kind: 'login-error' }
        : { kind: 'other', error: x };
    }),

  register: (ctx: ActionContext<State, RootState>, payload: RegisterPayload) => axios
    .post('/api/auth/register', payload)
    .catch((x: AxiosError) => {
      throw (x.response && 'DuplicateUserName' in x.response.data)
        ? { kind: 'username-already-exists', username: payload.username }
        : { kind: 'other', error: x };
    }).then(_ => ctx.dispatch('login', {
      username: payload.username,
      password: payload.password
    }))

};

export const createModule = (state: State): Module<State, RootState> => ({
  namespaced: true,
  state,
  getters,
  mutations,
  actions,
});