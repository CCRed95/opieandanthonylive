<template>
  <v-container grid-list-lg>
    <v-layout row justify-center wrap>
      <v-flex xs12 sm4>
        <v-responsive :aspect-ratio="1/1">
          <v-img :src="artwork" />
        </v-responsive>
      </v-flex>
      <v-flex x12 sm8>
        <span style="display:block; text-align: center; font-size: 12px"> {{ title }} </span>
        <span style="display:block; text-align: center; font-size: 12px"> {{ show }} </span>
        <timeline />
        <player-controls style="margin: 0 10px;"/>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import PlayerControls from '@/components/media-player/controls.vue';
import Timeline       from '@/components/media-player/timeline.vue';

import { Metadata } from '@/store';
import { Track }    from '@/store/audio';
import { maybeStr } from '@/util';

const audio = namespace('audio');

@Component({
  components: {
    PlayerControls,
    Timeline,
  },
})
export default class Player extends Vue {

  @audio.Getter('currentTrack') public currentTrack?: Track<Metadata>;

  get title() {
    return maybeStr(this.currentTrack, (t) => t.metadata.title);
  }

  get show() {
    return maybeStr(this.currentTrack, (t) => t.metadata.show);
  }

  get artwork() {
    return maybeStr(this.currentTrack, (t) => t.metadata.artwork);
  }

}
</script>
