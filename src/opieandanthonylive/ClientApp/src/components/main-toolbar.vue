<template>
  <v-toolbar app dark dense color="primary" scroll-off-screen>

    <v-toolbar-side-icon
      @click="$emit('nav-clicked')" />

    <v-toolbar-title>
      opieandanthonylive
    </v-toolbar-title>

    <v-spacer />
    
    <v-menu offset-y offset-x>
      <v-btn icon slot="activator">
        <v-icon large>
          mdi-account-circle
        </v-icon>
      </v-btn>
      <v-list v-if="isSignedIn">
        <v-list-tile>
          <v-list-tile-title @click="signOut">Sign out</v-list-tile-title>
        </v-list-tile>
      </v-list>
      <v-list v-else>
        <v-list-tile to="/sign-in">
          <v-list-tile-title>Sign in</v-list-tile-title>
        </v-list-tile>
        <v-list-tile to="/create-account">
          <v-list-tile-title>Create account</v-list-tile-title>
        </v-list-tile>
      </v-list>
    </v-menu>

  </v-toolbar>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

const auth = namespace('auth');

@Component
export default class MainToolbar extends Vue {
  @auth.Mutation('signOut')  public signOut!: () => void;
  @auth.Getter('isSignedIn') public isSignedIn!: boolean;
}
</script>