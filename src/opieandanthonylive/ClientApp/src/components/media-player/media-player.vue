<template>

  <div class="media-player">
    <badge/>
    <controls/>
    <volume-control/>
    <timeline style="flex: 1"/>
    <playlist/>
  </div>

</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

import Controls from './controls.vue';
import Timeline from './timeline.vue';
import VolumeControl from './volume-control';
import Badge from './badge';
import Playlist from './playlist';

@Component({
  components: {
    Controls,
    Timeline,
    VolumeControl,
    Badge,
    Playlist,
  },
})
export default class MediaPlayerComponent extends Vue {
}

</script>

<style>
.media-player {
  width: 100%;
  height: 100%;
  padding: 0 15px;
  margin: 0 auto 0 auto;
  display: flex;
  align-items: center;
}

.media-player-volume-wrapper {
  border-top: 0px solid var(--media-player-border);
  border-left: 1px solid var(--media-player-border);
  border-right: 1px solid var(--media-player-border);
  position: absolute;
  height: 0px;
  bottom: 40px;
  width: 100%;
  background: var(--media-player-background);
  padding: 0 15px;
  margin: 0 0;
  transition: height 200ms;
}

.media-player-volume-wrapper:hover {
  cursor: pointer;
}

.volume.hover .media-player-volume-background {
  display: block;
}

.media-player-volume-background {
  display: none;
  width: 2px;
  left: 16px;
  background: var(--media-player-slider-background);
  position: absolute;
  top: 13px;
  bottom: 13px;
}

.media-player-volume-position {
  width: 2px;
  background: var(--media-player-primary);
  position: absolute;
  bottom: 0;
}

.media-player-volume-handle {
  width: 8px;
  height: 8px;
  background: var(--media-player-primary);
  position: absolute;
  margin-left: -3px;
  margin-bottom: -3px;
  border-radius: 50%;
}

.media-player-badge {
  width: 350px;
  display: flex;
  align-items: center;
}

.media-image {
  background: var(--media-player-primary);
  border: 2px solid white;
  width: 44px;
  height: 44px;
  margin-right: 10px;
}
</style>
