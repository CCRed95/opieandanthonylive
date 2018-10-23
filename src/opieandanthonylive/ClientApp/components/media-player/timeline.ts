import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

const audio = namespace('audio');

const fmtTime = (isStopped: boolean, n: number) => {
  if (isStopped)
    return '--:--:--';

  const seconds = n             % 60 | 0;
  const minutes = (n / 60)      % 60 | 0;
  const hours   = (n / 60 / 60) % 60 | 0;

  const fmt = (x: number) =>
    ('00' + x).substr(-2, 2);

  return `${fmt(hours)}:${fmt(minutes)}:${fmt(seconds)}`;
}

@Component
export default class Timeline extends Vue {

  @audio.State('elapsed') elapsed!: number;
  @audio.State('duration') duration!: number;

  @audio.Getter('isStopped') isStopped!: boolean;

  get fmtElapsed(): string {
    return fmtTime(this.isStopped, this.elapsed);
  }

  get fmtDuration(): string {
    return fmtTime(this.isStopped, this.duration);
  }

  get percentage(): string {
    return this.isStopped ? '0%' : `${100.0 * this.elapsed / this.duration}%`;
  }

}