import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

const audio = namespace('audio');

@Component
export default class Volume extends Vue {

  @audio.State('volume') volume!: number;
  @audio.Action('volume') setVolume!: (v: number) => Promise<any>;

  get percentage(): string {
    return `${this.volume * 100.0}%`;
  }

}