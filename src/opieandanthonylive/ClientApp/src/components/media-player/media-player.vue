<template>

  <div class="media-player">
    <badge style="margin: 0 10px;"/>
    <controls style="margin: 0 10px;"/>
    <volume style="width: 200px; margin: 0 10px;"/>
    <timeline style="flex: 1; margin: 0 10px;"/>
    <playlist/>
  </div>

</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

import Controls from './controls.vue';
import Timeline from './timeline.vue';
import Volume from './volume.vue';
import Badge from './badge';
import Playlist from './playlist';

@Component({
  components: {
    Controls,
    Timeline,
    Volume,
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
