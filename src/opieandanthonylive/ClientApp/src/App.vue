<template>
  <div style="min-height: 100vh;">

    <drawer ref="drawer">

      <div class="mdc-drawer__header">
        <h3 class="mdc-drawer__title">opieandanthonylive</h3>
        <h6 class="mdc-list-group__subheader">Navigation</h6>
      </div>

      <div class="mdc-drawer__content">
        <nav class="mdc-list">

          <router-link to="/" class="mdc-list-item mdc-list-item--activated" href="#" tabindex="0" aria-selected="true">
            <i class="material-icons mdc-list-item__graphic" aria-hidden="true">home</i>
            Home
          </router-link>

          <hr class="mdc-list-divider">

          <router-link to="/sign-in" class="mdc-list-item" href="#" tabindex="0" aria-selected="true">
            <i class="material-icons mdc-list-item__graphic" aria-hidden="true">account_circle</i>
            Sign In
          </router-link>

          <router-link to="/create-account" class="mdc-list-item" href="#" tabindex="0" aria-selected="true">
            <i class="material-icons mdc-list-item__graphic" aria-hidden="true">account_circle</i>
            Create Account
          </router-link>

        </nav>
      </div>

    </drawer>

    <top-app-bar title="opieandanthonylive" @navigation-clicked="$refs.drawer.open()"/>

    <router-view class="mdc-top-app-bar--fixed-adjust" />

    <footer style="position: fixed; bottom: 0; width: 100%;">
      <media-player />
    </footer>

  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import Drawer from './components/Drawer';
import TopAppBar from './components/TopAppBar';
import MediaPlayer from './components/media-player/media-player';

@Component({
  components: {
    Drawer,
    TopAppBar,
    MediaPlayer,
  },
})
export default class App extends Vue {
}
</script>