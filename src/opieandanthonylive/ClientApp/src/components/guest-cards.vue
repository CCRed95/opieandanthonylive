<template>
  <v-container grid-list-lg fluid>
    <v-layout row wrap>
      <v-flex xs6 sm3 md2 v-for="i in artists" :key="i">
        <guest-card :image="i.image" :name="i.name" :shows="i.shows" />
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop, Watch } from 'vue-property-decorator';

import GuestCard from '@/components/guest-card.vue';
import Axios from 'axios';

const initArray = <T>(elem: T, length: number) =>
  (Array.apply(elem, Array(length)) as T[]).map(() => elem);

interface Artist {
  image: string;
  name: string;
  shows: number;
}

const unknownArtist: Artist = {
  image: '',
  name: '',
  shows: 0,
};

@Component({
  components: {
    GuestCard,
  },
})
export default class GuestCards extends Vue {

  @Prop(Number) private showId!: number;

  private artists: Artist[] =
    initArray(unknownArtist, 12);

  @Watch('$route')
  private onRouteChanged() {
    this.fetchData();
  }

  private async created() {
    this.fetchData();
  }

  private async fetchData() {
    try {
      const response = await Axios.get(`/api/shows/${this.showId}/guests`);
      this.artists = response.data;
    } catch {
      alert('whoops');
    }
  }

}
</script>
