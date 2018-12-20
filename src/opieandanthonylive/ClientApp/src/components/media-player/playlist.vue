<template>
  <v-list dense two-line>

    <v-divider/>

    <draggable v-model="playlist.tracks" :options="{ handle: '.drag-handle', 'animation': 150, 'ghostClass': 'drag-ghost' }">

      <div v-for="(track, i) in playlist.tracks" :key="i">

        <v-list-tile @click="onClick(i)">
          
          <v-list-tile-action class="drag-handle">
            <v-icon>mdi-drag</v-icon>
          </v-list-tile-action>
          
          <v-list-tile-avatar tile>
            <v-img :src="track.metadata.artwork" />
          </v-list-tile-avatar>
          
          <v-list-tile-content :class="{ 'primary--text': track === currentTrack }" class="text--lighten-1">
            <v-list-tile-title>{{ track.metadata.title }}</v-list-tile-title>
            <v-list-tile-sub-title>{{ track.metadata.show }}</v-list-tile-sub-title>
          </v-list-tile-content>
          
        </v-list-tile>
        <v-divider />

      </div>

    </draggable>

  </v-list>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';
import draggable from 'vuedraggable';

import { Metadata } from '@/store';
import { Playlist, Track } from '@/store/audio';

const audio = namespace('audio');

@Component({
  components: {
    draggable,
  },
})
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

<style scoped>
.drag-handle {
  cursor: move;
}
.drag-ghost {
  opacity: 0.1;
}
</style>
