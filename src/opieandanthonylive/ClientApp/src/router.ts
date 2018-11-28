// tslint:disable:max-line-length

import Vue from 'vue';
import Router, {NavigationGuard, RouteConfig } from 'vue-router';
import { Store } from 'vuex';
import VueRouter from 'vue-router';

import Home from './views/Home.vue';

Vue.use(Router);

const SIGN_IN        = '/sign-in';
const CREATE_ACCOUNT = '/create-account';
export const authRoutes = [SIGN_IN, CREATE_ACCOUNT];

export const mkRouter = <S>(store: Store<S>) => {

  const authGuard: NavigationGuard = (to, from, next) =>
    store.getters['auth/isSignedIn']
      ? next(false)
      : next();

  const routes = [
    { path: '/',          component: Home },
    { path: '/counter',   component: () => import(/* webpackChunkName: "counter" */   './views/Counter.vue') },
    { path: '/fetchdata', component: () => import(/* webpackChunkName: "fetchdata" */ './views/FetchData.vue') },

    { path: SIGN_IN,        beforeEnter: authGuard, component: () => import(/* webpackChunkName: "sign-in" */        './views/SignIn.vue') },
    { path: CREATE_ACCOUNT, beforeEnter: authGuard, component: () => import(/* webpackChunkName: "create-account" */ './views/CreateAccount.vue') },
  ];

  return new VueRouter({mode: 'history', base: process.env.BASE_URL, routes});
};
