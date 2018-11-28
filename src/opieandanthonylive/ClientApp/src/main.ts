import Vue from 'vue';
import { sync } from 'vuex-router-sync';

import './theme.scss';

import App from './App.vue';
import { store } from './store';
import { mkRouter } from './router';

Vue.config.productionTip = false;

const router = mkRouter(store);
const unsync = sync(store, router);

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');
