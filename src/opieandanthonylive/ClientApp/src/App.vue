<template>
  <v-app dark>

    <v-navigation-drawer fixed app v-model="isDrawerOpen">

      <v-list dense>
        <v-list-group value="true">
          <v-list-tile slot="activator">
            <v-list-tile-title>ARCHIVES</v-list-tile-title>
          </v-list-tile>
          <v-list-tile v-for="(show, i) in shows" :key="i" :to="show.to">
            <v-list-tile-action />
            <v-list-tile-title v-text="show.name" />
          </v-list-tile>
        </v-list-group>
      </v-list>

      <v-list dense>
        <v-list-tile v-for="(sort, i) in sorts" :key="i">
          <v-list-tile-action />
          <v-list-tile-title v-text="sort" />
        </v-list-tile>
      </v-list>

      <v-list dense>
        <v-list-group value="true">
          <v-list-tile slot="activator">
            <v-list-tile-title>PLAYLISTS</v-list-tile-title>
          </v-list-tile>
          <v-list-tile v-for="(playlist, i) in playlists" :key="i">
            <v-list-tile-action />
            <v-list-tile-title v-text="playlist" />
          </v-list-tile>
        </v-list-group>
      </v-list>

    </v-navigation-drawer>

    <main-toolbar @nav-clicked="isDrawerOpen = !isDrawerOpen" />

    <v-content>
      <v-container fluid class="app-container">
        <router-view></router-view>
      </v-container>
    </v-content>

    <v-footer app height="50px">
      <media-player />
    </v-footer>

    <v-snackbar v-model="snackbar" vertical bottom :timeout="6000">
      {{ error }}
      <v-btn color="error" flat @click="snackbar=false;">Close</v-btn>
    </v-snackbar>

  </v-app>
</template>

<style>
.app-container {
  height: 100%;
}
</style>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop, Watch } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import MediaPlayer from '@/components/media-player/media-player.vue';
import MainToolbar from '@/components/main-toolbar.vue';

const error = namespace('error');

@Component({
  components: {
    MediaPlayer,
    MainToolbar,
  },
})
export default class App extends Vue {

  private isDrawerOpen: null | boolean = null;

  private shows = [
    { name: 'Opie and Anthony',   to: '/shows/1/by-artist' },
    { name: 'Ron and Fez',        to: '/shows/2/by-artist' },
    { name: 'Ricky Gervais Show', to: '/shows/3/by-artist' },
    { name: 'Cumtown',            to: '/shows/4/by-artist' },
    { name: 'Than and Sam Show',  to: '/shows/5/by-artist' },
  ];

  private sorts = [
    'By Date',
    'By Artist',
    'By Search Term',
    'Radio',
  ];

  private playlists = [
    'Playlist 1',
    'Playlist 2',
    'Playlist 3',
  ];

  private snackbar = false;
  @error.State('error') private error!: null | string;
  @error.State('count') private errorCount!: number;
  @Watch('errorCount')  private onError() { this.snackbar = true; }

}
</script>