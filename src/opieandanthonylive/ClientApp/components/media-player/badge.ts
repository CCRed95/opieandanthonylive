import Vue from "vue";
import { Component } from 'vue-property-decorator';
import { namespace } from "vuex-class";

import { Metadata } from "../../store";
import { Track } from "../../store/audio";
import { maybeStr } from "../../helpers";

const audio = namespace('audio');

@Component
export default class Timeline extends Vue {

  @audio.Getter('currentTrack') currentTrack?: Track<Metadata>;

  get title() {
    return maybeStr(this.currentTrack, t => t.metadata.title);
  }

  get show() {
    return maybeStr(this.currentTrack, t => t.metadata.show);
  }

  get artwork() {
    return maybeStr(this.currentTrack, t => t.metadata.artwork);
  }

}