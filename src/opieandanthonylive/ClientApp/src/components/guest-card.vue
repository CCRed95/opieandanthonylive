<template>
  <v-card>
    <v-responsive :aspect-ratio="1/1">
      <v-img :src="image"></v-img>
    </v-responsive>
    <v-card-title>
      <div>
        <span>{{ name }}</span><br>
        <span class="grey--text">{{ fmtShows }}</span>
      </div>
    </v-card-title>
  </v-card>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component
export default class GuestCard extends Vue {
  @Prop(String) private image!:  string;
  @Prop(String) private name!:   string;
  @Prop(Number) private shows!: number;

  private get fmtShows() {
    return this.shows === 0
      ? ''
      : `${this.shows} shows`;
  }
}
</script>
