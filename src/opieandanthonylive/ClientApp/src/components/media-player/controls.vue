<template>
  <div class="media-player-controls">

    <v-btn icon disabled>
      <v-icon>mdi-shuffle-variant</v-icon>
    </v-btn>

    <v-btn icon @click="prev">
      <v-icon>mdi-step-backward</v-icon>
    </v-btn>

    <v-btn outline icon large @click="playOrPause">
      <v-icon>mdi-play</v-icon>
    </v-btn>

    <v-btn icon @click="next">
      <v-icon>mdi-step-forward</v-icon>
    </v-btn>

    <v-btn icon disabled>
      <v-icon>mdi-repeat</v-icon>
    </v-btn>

  </div>
  </template>

<script lang="ts">
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

</script>