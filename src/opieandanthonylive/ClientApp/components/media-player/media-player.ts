import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class MediaPlayerComponent extends Vue {

  get elapsedFmt() {
    return "1:23";
  }

  get durationFmt() {
    return "2:34";
  }

}