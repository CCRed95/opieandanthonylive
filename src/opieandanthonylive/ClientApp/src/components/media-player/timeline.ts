// tslint:disable:no-bitwise

import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

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

@Component
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

  public get percentage(): string {
    return this.isEmpty ? '0%' : `${100.0 * this.elapsed / this.duration}%`;
  }

  public startSeeking(event: MouseEvent) {
    const div = this.$refs.timelineWrapper as HTMLDivElement;

    const onMove = (ev: MouseEvent) => {
      const width = div.clientWidth;
      const left = div.getBoundingClientRect().left;
      const offset = clamp(0, ev.clientX - left, width);
      this.seekElapsed = offset / width * this.duration;
    };

    const onGrab = () => { this.isSeeking = true; onMove(event); };
    const onDrop = () => { this.isSeeking = false; this.seek(this.seekElapsed); };

    drag(onGrab, onMove, onDrop);
  }

}
