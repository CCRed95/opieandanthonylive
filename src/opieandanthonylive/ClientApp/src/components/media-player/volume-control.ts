import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import { drag, clamp } from '@/util';

const audio = namespace('audio');

@Component
export default class Volume extends Vue {

  @audio.State('muted')       public isMuted!: boolean;
  @audio.Action('toggleMute') public toggleMute!: () => Promise<any>;
  @audio.Getter('volume')     private storeVolume!: number;
  @audio.Action('volume')     private setVolume!: (v: number) => Promise<any>;

  get volumeButtonClass(): string {
    return (
      this.storeVolume > 0.5
        ? 'fa-volume-up'
        : this.storeVolume > 0
          ? 'fa-volume-down'
          : 'fa-volume-mute'
    );
  }

  private isSliding = false;
  private isHover = false;

  get volumeClass() {
    return this.isSliding || this.isHover ? 'hover' : '';
  }

  public dragVolume(event: MouseEvent) {
    const target = this.$refs.sliderBackground as HTMLDivElement;

    const onMove = (ev: MouseEvent) => {
      const height = target.clientHeight;
      const bottom = target.getBoundingClientRect().bottom;
      const offset = clamp(0, bottom - ev.clientY, height);
      const volume = offset / height;

      this.setVolume(volume);
    };

    const onGrab = () => { this.isSliding = true;  onMove(event); };
    const onDrop = () => { this.isSliding = false; };

    drag(onGrab, onMove, onDrop);
  }

  public beginHover() { this.isHover = true; }
  public endHover() { this.isHover = false; }

  get fmtPercentage(): string {
    return `${this.storeVolume * 100.0}%`;
  }

}
