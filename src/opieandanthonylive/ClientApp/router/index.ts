import Vue from "vue";
import VueRouter, { NavigationGuard, RouteConfig } from "vue-router";
import { Store } from "vuex";

Vue.use(VueRouter);

const SIGN_IN        = '/sign-in';
const CREATE_ACCOUNT = '/create-account';
export const authRoutes = [SIGN_IN, CREATE_ACCOUNT];

export const mkRouter = <S>(store: Store<S>) => {

  const authGuard: NavigationGuard = (to, from, next) =>
    store.getters['auth/isSignedIn']
      ? next(false)
      : next();

  const routes: RouteConfig[] = [
    { path: '/',          component: require('../components/home/home.vue.html').default           },
    { path: '/counter',   component: require('../components/counter/counter.vue.html').default     },
    { path: '/fetchdata', component: require('../components/fetchdata/fetchdata.vue.html').default },

    { path: SIGN_IN,        component: require('../components/create-account/sign-in.vue.html').default,        beforeEnter: authGuard },
    { path: CREATE_ACCOUNT, component: require('../components/create-account/create-account.vue.html').default, beforeEnter: authGuard },
  ];

  return new VueRouter({ routes, mode: 'history' });

}
