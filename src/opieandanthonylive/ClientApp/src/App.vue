<template>
  <v-app>

    <v-navigation-drawer app v-model="drawerOpen">
    </v-navigation-drawer>

    <v-toolbar app>
      <v-toolbar-side-icon @click="drawerOpen = !drawerOpen" />
      <v-toolbar-title>opieandanthonylive</v-toolbar-title>
    </v-toolbar>

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

@Component({
  components: {
    MediaPlayer,
  },
})
export default class App extends Vue {
  @Prop(Boolean) public drawerOpen: boolean = false;
}
</script>