import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import { clamp, drag } from '../../helpers';

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

  isSeeking = false;
  seekElapsed = 0;

  @audio.State('elapsed') storeElapsed!: number;
  @audio.State('duration') duration!: number;
  @audio.Getter('isStopped') isStopped!: boolean;
  @audio.Action('seek') seek!: (time: number) => Promise<any>;

  get elapsed() {
    return this.isSeeking
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

  startSeeking(ev: MouseEvent) {
    const div = ev.target as HTMLDivElement;

    const onMove = (ev: MouseEvent) => {
      const width = div.clientWidth;
      const left = div.getBoundingClientRect().left;
      const offset = clamp(0, ev.clientX - left, width);
      this.seekElapsed = offset / width * this.duration;
    }

    const onGrab = ()               => { this.isSeeking = true; onMove(ev); };
    const onDrop = (ev: MouseEvent) => { this.isSeeking = false; this.seek(this.seekElapsed); }

    drag(onGrab, onMove, onDrop);
  }

}