<template>
  <div class="media-player-timeline">
    <span>{{ fmtElapsed }}</span>
    <slider class="media-player-slider" v-model="progress" @drag="onDrag" @dragging="onDragging" @dragged="onDragged" />
    <span>{{ fmtDuration }}</span>
  </div>
</template>

<script lang="ts">
// tslint:disable:no-bitwise
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import Slider from './slider.vue';
import { clamp, drag } from '@/util';

const audio = namespace('audio');

const fmtTime = (isEmpty: boolean, n: number) => {
  if (isEmpty) {
    return '--:--:--';
  }

  const seconds =  n            % 60 | 0;
  const minutes = (n / 60)      % 60 | 0;
  const hours   = (n / 60 / 60) % 60 | 0;

  const fmt = (x: number) =>
    ('00' + x).substr(-2, 2);

  return `${fmt(hours)}:${fmt(minutes)}:${fmt(seconds)}`;
};

@Component({
  components: {
    Slider,
  },
})
export default class Timeline extends Vue {

  private isSeeking = false;
  private seekElapsed = 0;

  @audio.State('elapsed')  private storeElapsed!: number;
  @audio.State('duration') private duration!: number;
  @audio.Getter('isEmpty') private isEmpty!: boolean;
  @audio.Action('seek')    private seek!: (time: number) => Promise<any>;

  get elapsed() {
    return this.isSeeking
      ? this.seekElapsed
      : this.storeElapsed;
  }

  public get fmtElapsed() {
    return fmtTime(this.isEmpty, this.elapsed);
  }

  public get fmtDuration(): string {
    return fmtTime(this.isEmpty, this.duration);
  }

  public get progress() {
    return this.elapsed / this.duration;
  }

  public onDrag(value: number) {
    this.isSeeking = true;
  }

  public onDragging(value: number) {
    this.seekElapsed = value * this.duration;
  }

  public async onDragged(value: number) {
    this.isSeeking = false;
    await this.seek(value * this.duration);
  }

}
</script>

<style>

.media-player-timeline {
  display: flex;
  align-items: center;
}

.media-player-slider {
  flex: 1;
  margin: 0 10px;
}

</style>