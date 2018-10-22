import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

const media = namespace('media');

@Component
export default class Controls extends Vue {

  @media.Getter('isPlaying') isPlaying!: boolean;

  @media.Mutation('pause') pause!: () => void;
  @media.Action('play') play!: () => Promise<void>;

  get playClass() {
    return this.isPlaying ? 'fa-pause' : 'fa-play';
  }

  playOrPause() {
    if (this.isPlaying) {
      this.pause();
    } else {
      this.play();
    }
  }

}