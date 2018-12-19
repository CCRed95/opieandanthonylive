<template>
  <v-list dense two-line style="padding: 0;">
    <template v-for="(track, i) in playlist.tracks">

      <v-divider :key="`${i}-divider`" v-if="i > 0" />

      <v-list-tile :key="`${i}-tile`" @click="onClick(i)">

        <v-list-tile-avatar>
          <v-img :src="track.metadata.artwork" />
        </v-list-tile-avatar>

        <v-list-tile-content :class="{ 'accent--text': track === currentTrack }" class="text--darken-1">
          <v-list-tile-title>{{ track.metadata.title }}</v-list-tile-title>
          <v-list-tile-sub-title>{{ track.metadata.show }}</v-list-tile-sub-title>
        </v-list-tile-content>

      </v-list-tile>

    </template>
  </v-list>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import { Metadata } from '@/store';
import { Playlist, Track } from '@/store/audio';

const audio = namespace('audio');

@Component
export default class PlaylistControl extends Vue {
  @audio.State('playlist') private playlist!: Playlist<Metadata>;

  @audio.Getter('currentTrack') private currentTrack!: Track<Metadata>;

  @audio.Action('currentTrack') private setCurrent!: (i: number) => Promise<void>;
  @audio.Action('play')         private play!:       () => Promise<void>;

  private async onClick(i: number) {
    await this.setCurrent(i);
    await this.play();
  }

}
</script>