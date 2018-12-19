<template>
  <div class="media-player-controls">

    <v-btn icon @click="toggleShuffle">
      <v-icon :color="this.shuffle ? 'primary' : ''">mdi-shuffle-variant</v-icon>
    </v-btn>

    <v-btn icon small flat @click="prev">
      <v-icon>mdi-step-backward</v-icon>
    </v-btn>

    <v-btn :outline="!isLoading" icon @click="playOrPause" :loading="isLoading">
      <v-icon>{{ playClass }}</v-icon>
    </v-btn>

    <v-btn icon @click="next">
      <v-icon>mdi-step-forward</v-icon>
    </v-btn>

    <v-btn icon @click="toggleRepeat">
      <v-icon :color="this.repeat ? 'primary' : ''">mdi-repeat</v-icon>
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

  @audio.Action('pause') private pause!: () => Promise<any>;
  @audio.Action('play')  private play!: () => Promise<any>;
  @audio.Action('prev')  private prev!: () => Promise<any>;
  @audio.Action('next')  private next!: () => Promise<any>;

  @audio.Getter('isLoading') private isLoading!: boolean;
  @audio.Getter('isPlaying') private isPlaying!: boolean;

  @audio.State('shuffle') private shuffle!: boolean;
  @audio.Mutation('shuffle') private setShuffle!: (v: boolean) => void;

  @audio.State('repeat')  private repeat!: boolean;
  @audio.Mutation('repeat') private setRepeat!: (v: boolean) => void;

  get playClass() {
    return this.isPlaying || this.isLoading
      ? 'mdi-pause'
      : 'mdi-play';
  }

  @audio.Action('playOrPause')
  private playOrPause!: () => Promise<void>;

  private toggleRepeat() {
    this.setRepeat(!this.repeat);
  }

  private toggleShuffle() {
    this.setShuffle(!this.shuffle);
  }

}

</script>