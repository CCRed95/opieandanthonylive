import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import { drag, clamp } from '../../helpers';

const audio = namespace('audio');

@Component
export default class Volume extends Vue {

  @audio.State('volume') storeVolume!: number;
  @audio.Action('volume') setVolume!: (v: number) => Promise<any>;

  get fmtPercentage(): string {
    return `${this.storeVolume * 100.0}%`;
  }

  dragVolume(ev: MouseEvent) {
    const target = this.$refs.sliderBackground as HTMLDivElement;

    const onMove = (ev: MouseEvent) => {
      const height = target.clientHeight;
      const bottom = target.getBoundingClientRect().bottom;
      const offset = clamp(0, bottom - ev.clientY, height);
      const volume = offset / height;

      this.setVolume(volume);
    };

    const onGrab = () => { onMove(ev); };
    const onDrop = () => {};

    drag(onGrab, onMove, onDrop);
  }

}