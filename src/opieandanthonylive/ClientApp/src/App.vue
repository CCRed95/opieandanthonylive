<template>
  <v-app dark>

    <v-navigation-drawer app v-model="isDrawerOpen">
    </v-navigation-drawer>

    <main-toolbar @nav-clicked="isDrawerOpen = !isDrawerOpen"/>

    <v-content>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </v-content>

    <v-footer app>
      <media-player />
    </v-footer>

  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import MediaPlayer from '@/components/media-player/media-player';
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