import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

const audio = namespace('audio');

@Component
export default class Controls extends Vue {

  @audio.Getter('isLoading') isLoading!: boolean;
  @audio.Getter('isPlaying') isPlaying!: boolean;

  @audio.Action('pause') pause!: () => void;
  @audio.Action('play') play!: () => void;
  @audio.Action('prev') prev!: () => void;
  @audio.Action('next') next!: () => void;

  get playClass() {
    if (this.isLoading)
      return 'fa-sync';
    else if (this.isPlaying)
      return 'fa-pause';
    else
      return 'fa-play';
  }

  playOrPause() {
    this.isPlaying || this.isLoading ? this.pause() : this.play();
  }

}