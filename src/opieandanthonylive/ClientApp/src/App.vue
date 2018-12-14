<template>
  <v-app dark>

    <v-navigation-drawer app v-model="isDrawerOpen">

      <v-toolbar>
        <v-list>
          <v-list-tile>
            <v-list-tile-title>
              O&A RADIO
            </v-list-tile-title>
          </v-list-tile>
        </v-list>
      </v-toolbar>

      <v-list>
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

      <v-list>
        <v-list-tile v-for="(sort, i) in sorts" :key="i">
          <v-list-tile-action />
          <v-list-tile-title v-text="sort" />
        </v-list-tile>
      </v-list>

      <v-list>
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

    <main-toolbar @nav-clicked="isDrawerOpen = !isDrawerOpen"/>

    <v-content>
      <v-container fluid class="app-container">
        <router-view></router-view>
      </v-container>
    </v-content>

    <v-footer app height="50px">
      <media-player />
    </v-footer>

  </v-app>
</template>

<style>
.app-container {
  height: 100%;
}
</style>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import MediaPlayer from '@/components/media-player/media-player.vue';
import MainToolbar from '@/components/main-toolbar.vue';

@Component({
  components: {
    MediaPlayer,
    MainToolbar,
  },
})
export default class App extends Vue {
  public isDrawerOpen: boolean | null = null;

  public shows = [
    { name: 'Opie and Anthony',   to: '/shows/1/by-artist' },
    { name: 'Ron and Fez',        to: '/shows/2/by-artist' },
    { name: 'Ricky Gervais Show', to: '/shows/3/by-artist' },
    { name: 'Cumtown',            to: '/shows/4/by-artist' },
    { name: 'Than and Sam Show',  to: '/shows/5/by-artist' },
  ];

  public sorts = [
    'By Date',
    'By Artist',
    'By Search Term',
    'Radio',
  ];

  public playlists = [
    'Playlist 1',
    'Playlist 2',
    'Playlist 3',
  ];

}
</script>