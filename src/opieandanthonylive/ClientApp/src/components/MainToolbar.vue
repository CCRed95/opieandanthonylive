<template>
  <v-toolbar app>
    <v-toolbar-side-icon @click="$emit('nav-clicked')" />
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
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class MainToolbar extends Vue {
}
</script>