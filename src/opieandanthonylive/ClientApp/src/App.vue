<template>
  <v-app dark>

    <v-navigation-drawer app v-model="drawerOpen">
    </v-navigation-drawer>

    <v-toolbar app>
      <v-toolbar-side-icon @click="drawerOpen = !drawerOpen" />
      <v-toolbar-title>opieandanthonylive</v-toolbar-title>
      <v-spacer />
      
      <v-menu offset-y offset-x>
        <v-btn icon primary slot="activator">
          <v-icon>
            mdi-account-circle
          </v-icon>
        </v-btn>
        <v-list>
          <v-list-tile>
            <v-list-tile-title>Sign in</v-list-tile-title>
          </v-list-tile>
          <v-list-tile>
            <v-list-tile-title>Create account</v-list-tile-title>
          </v-list-tile>
        </v-list>
      </v-menu>

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