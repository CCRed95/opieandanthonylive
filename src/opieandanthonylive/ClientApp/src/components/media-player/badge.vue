<template>
  <div class="media-player-badge">
    <img class="media-image" :src="artwork"/>
    <div style="flex: 1">
      <span style="display:block; font-size: 12px"> {{ title }} </span>
      <span style="display:block; font-size: 12px"> {{ show }} </span>
    </div>
  </div>
</template>
<script src="./badge.ts"></script>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import { maybeStr } from '@/util';
import { Metadata } from '@/store';
import { Track } from '@/store/audio';

const audio = namespace('audio');

@Component
export default class Timeline extends Vue {

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
