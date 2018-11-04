import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import { drag, clamp } from '../../helpers';

const audio = namespace('audio');

@Component
export default class Volume extends Vue {

  @audio.State('muted')       isMuted!: boolean;
  @audio.Getter('volume')     storeVolume!: number;
  @audio.Action('volume')     setVolume!: (v: number) => Promise<any>;
  @audio.Action('toggleMute') toggleMute!: () => Promise<any>;

  get volumeButtonClass(): string {
    if (this.storeVolume > 0.5)
      return 'fa-volume-up';
    else if (this.storeVolume > 0)
      return 'fa-volume-down';
    else
      return 'fa-volume-mute';
  }

  isSliding = false;
  isHover = false;

  get volumeClass() {
    return this.isSliding || this.isHover ? "hover" : "";
  }

  beginHover(ev: MouseEvent) { this.isHover = true;  }
  endHover(ev: MouseEvent)   { this.isHover = false; }

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

    const onGrab = () => { this.isSliding = true;  onMove(ev); };
    const onDrop = () => { this.isSliding = false; };

    drag(onGrab, onMove, onDrop);
  }

}