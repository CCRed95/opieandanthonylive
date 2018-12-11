<template>

  <div class="media-player">
    <badge/>
    <controls/>
    <volume-control/>
    <slider style="flex: 1;"/>
    <timeline/>
    <playlist/>
  </div>

</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

import Slider from './slider.vue';
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
    Slider,
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

.media-player-button:focus {
  outline:0;
}

.media-player-button * {
  color: var(--media-player-button);
}

.media-player-play {
  background: var(--media-player-primary);
  border-radius: 50%;
}

.media-player-timeline {
  position: relative;
  display: flex;
  flex: 1;
  align-items: center;
  font-size: 13px;
}

.media-player-elapsed {
  height: 40px;
  width: 55px;
  line-height: 40px;
  text-align: right;
}

.media-player-duration {
  height: 40px;
  width: 55px;
  line-height: 40px;
  text-align: left;
}

.media-player-timeline-wrapper {
  display: block;
  margin: 0 10px;
  padding: 10px 0;
  height: 10px;
  position: relative;
  flex: 1;
}

.media-player-timeline-wrapper:hover {
  cursor: pointer;
}

.media-player-timeline-background {
  width: 100%;
  position: absolute;
  height: 4px;
  border-radius: 4px;
}

.media-player-timeline-position {
  position: absolute;
  height: 4px;
  border-radius: 4px;
}

.media-player-timeline-handle {
  height: 11px;
  width: 11px;
  margin-left: -4px;
  margin-top: -4px;
  border-radius: 50%;
  position: absolute;
}

.volume.hover .media-player-volume-wrapper {
  height: 120px;

  /* Too fast to notice? */
  border-top: 1px solid var(--media-player-border);
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
  width: 40px;
  height: 40px;
  margin-right: 10px;
}
</style>
