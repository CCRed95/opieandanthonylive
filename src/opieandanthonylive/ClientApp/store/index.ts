import Vue  from 'vue';
import Vuex, { Store } from 'vuex';

import { RootState } from './types';
import * as auth from './auth';

Vue.use(Vuex);

export const store: Store<RootState> = new Vuex.Store({

  modules: {
    auth: auth.createModule(auth.loadState())
  },

});