import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

const audio = namespace('audio');

@Component
export default class Controls extends Vue {

  @audio.Action('pause') public pause!: () => Promise<any>;
  @audio.Action('play')  public play!: () => Promise<any>;
  @audio.Action('prev')  public prev!: () => Promise<any>;
  @audio.Action('next')  public next!: () => Promise<any>;

  @audio.Getter('isLoading') private isLoading!: boolean;
  @audio.Getter('isPlaying') private isPlaying!: boolean;

  get playClass() {
    return (
      this.isLoading
        ? 'fa-sync'
        : this.isPlaying
          ? 'fa-pause'
          : 'fa-play'
    );
  }

  public playOrPause() {
    this.isPlaying || this.isLoading ? this.pause() : this.play();
  }

}
