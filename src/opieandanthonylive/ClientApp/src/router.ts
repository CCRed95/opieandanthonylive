// tslint:disable:max-line-length

import Vue from 'vue';
import Router, {NavigationGuard, RouteConfig } from 'vue-router';
import { Store } from 'vuex';
import VueRouter from 'vue-router';

import Home from './views/home.vue';
import Show from './views/show.vue';

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
    { path: '/',            name: 'opieandanthonylive', component: Home },
    { path: SIGN_IN,        name: 'Sign in',        beforeEnter: authGuard, component: () => import(/* webpackChunkName: "sign-in" */        './views/sign-in.vue') },
    { path: CREATE_ACCOUNT, name: 'Create account', beforeEnter: authGuard, component: () => import(/* webpackChunkName: "create-account" */ './views/create-account.vue') },

    {
      path: '/shows/:showId',
      redirect: '/shows/:showId/by-artist',
      component: Show,
      children: [
        {
          path: '',
          props: true,
          component: () => import(/* webpackChunkName: "show-guest-cards" */ './components/guest-cards.vue'),
        },
        {
          path: 'by-artist',
          props: true,
          component: () => import(/* webpackChunkName: "show-guest-cards" */ './components/guest-cards.vue'),
        },
        {
          path: 'by-date',
          component: Home,
        },
        {
          path: 'by-timeline',
          component: Home,
        },
      ],
    },
  ];

  return new VueRouter({mode: 'history', base: process.env.BASE_URL, routes});
};
