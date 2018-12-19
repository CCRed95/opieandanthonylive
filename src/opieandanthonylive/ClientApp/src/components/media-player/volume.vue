<template>
  <div class="media-player-volume">
    <v-btn icon class="media-player-volume-button" @click="toggleMuted">
      <v-icon>{{ volumeButtonClass }}</v-icon>
    </v-btn>
    <slider class="media-player-volume-slider" :value="volume" @dragging="setVolume" />
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';
import Slider from './slider.vue';

const audio = namespace('audio');

@Component({
  components: {
    Slider,
  },
})
export default class Volume extends Vue {

  @audio.State('muted')        private isMuted!: boolean;
  @audio.Action('toggleMuted') private toggleMuted!: () => Promise<any>;
  @audio.Getter('volume')      private volume!: number;
  @audio.Action('volume')      private setVolume!: (v: number) => Promise<any>;

  get volumeButtonClass(): string {
    if (this.isMuted) {
      return 'mdi-volume-mute';
    }

    if (this.volume > 0.75) {
      return 'mdi-volume-high';
    }

    if (this.volume > 0.25) {
      return 'mdi-volume-medium';
    }

    return 'mdi-volume-low';
  }


}
</script>

<style>

.media-player-volume {
  display: flex;
  align-items: center;
}
.media-player-volume-button {
  margin-right: 0;
}

.media-player-volume-slider {
  flex: 1;
}

</style>
