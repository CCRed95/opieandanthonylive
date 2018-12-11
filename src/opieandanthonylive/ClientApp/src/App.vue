<template>
  <v-app dark>

    <v-navigation-drawer app v-model="isDrawerOpen">
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
import MainToolbar from '@/components/MainToolbar.vue';

@Component({
  components: {
    MediaPlayer,
    MainToolbar,
  },
})
export default class App extends Vue {
  public isDrawerOpen: boolean | null = null;
}
</script>