import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import { clump } from '../../helpers';

const audio = namespace('audio');

const fmtTime = (isStopped: boolean, n: number) => {
  if (isStopped)
    return '--:--:--';

  const seconds = n % 60 | 0;
  const minutes = (n / 60) % 60 | 0;
  const hours = (n / 60 / 60) % 60 | 0;

  const fmt = (x: number) =>
    ('00' + x).substr(-2, 2);

  return `${fmt(hours)}:${fmt(minutes)}:${fmt(seconds)}`;
}

@Component
export default class Timeline extends Vue {

  isMouseDown = false;
  seekElapsed = 0;

  @audio.State('elapsed') storeElapsed!: number;
  @audio.State('duration') duration!: number;
  @audio.Getter('isStopped') isStopped!: boolean;
  @audio.Action('seek') seek!: (time: number) => Promise<any>;

  get elapsed() {
    return this.isMouseDown
      ? this.seekElapsed
      : this.storeElapsed;
  }

  get fmtElapsed() {
    return fmtTime(this.isStopped, this.elapsed);
  }

  get fmtDuration(): string {
    return fmtTime(this.isStopped, this.duration);
  }

  get percentage(): string {
    return this.isStopped ? '0%' : `${100.0 * this.elapsed / this.duration}%`;
  }

  updateElapsed(ev: MouseEvent) {
    if (!(ev.target instanceof HTMLDivElement))
      return;

    const duration = this.duration;
    const width = ev.target.clientWidth;

    const offset = clump(0, ev.offsetX, width);
    this.seekElapsed = offset / width * duration;
  }

  mouseDown(ev: MouseEvent) {
    this.isMouseDown = true;
    this.updateElapsed(ev);
  }

  mouseMove(ev: MouseEvent) {
    if (this.isMouseDown && ev.buttons == 0)
      this.mouseUp();
    if (this.isMouseDown)
      this.updateElapsed(ev);
  }

  mouseUp() {
    this.isMouseDown = false;
    this.seek(this.seekElapsed);
  }

}