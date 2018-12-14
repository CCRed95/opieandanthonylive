<template>
  <v-card>
    <v-responsive>
      <v-img :src="image"></v-img>
    </v-responsive>
    <v-card-title>
      <div>
        <span>{{ name }}</span><br>
        <span class="grey--text">{{ fmtNShows }}</span>
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
  @Prop(Number) private nShows!: number;

  private get fmtNShows() {
    return `${this.nShows} shows`;
  }
}
</script>
