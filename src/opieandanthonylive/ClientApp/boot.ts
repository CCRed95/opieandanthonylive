import './css/site.css';
import 'bootstrap';

import Vue from 'vue';
import { sync } from 'vuex-router-sync';

import { store } from './store';
import { mkRouter } from './router';

const router = mkRouter(store);
const unasync = sync(store, router);

new Vue({
  el: '#app-root',
  store,
  router,
  render: h => h(require('./components/app/app.vue.html').default)
});
