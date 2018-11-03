import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';
import { drag, clamp } from '../../helpers';

const audio = namespace('audio');

@Component
export default class Volume extends Vue {

  @audio.State('volume') volume!: number;
  @audio.Action('volume') setVolume!: (v: number) => Promise<any>;

  get percentage(): string {
    return `${this.volume * 100.0}%`;
  }

  dragVolume(ev: MouseEvent) {
    const target = this.$refs.sliderBackground as HTMLDivElement;

    const onMove = (ev: MouseEvent) => {
      const height = target.clientHeight;
      const bottom = target.getBoundingClientRect().bottom;
      const offset = clamp(0, bottom - ev.clientY, height);
      this.setVolume(offset / height);
    };

    const onGrab = ()               => { onMove(ev); };
    const onDrop = (ev: MouseEvent) => { };

    drag(onGrab, onMove, onDrop);

  }

}