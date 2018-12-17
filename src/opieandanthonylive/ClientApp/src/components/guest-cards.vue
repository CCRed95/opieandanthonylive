<template>
  <v-container grid-list-lg fluid>
    <v-layout row wrap>
      <v-flex xs6 sm3 md2 v-for="(a, i) in artists" :key="i">
        <guest-card :image="a.image" :name="a.name" :shows="a.shows" />
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop, Watch } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

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

const initialArtists =
  initArray(unknownArtist, 12);

const error = namespace('error');

@Component({
  components: {
    GuestCard,
  },
})
export default class GuestCards extends Vue {

  // Not a mistake. Vue shits itself in the dev console otherwise.
  @Prop(String) private showId!: number;

  @error.Mutation('error') private error!: (msg: string) => void;

  private artists = initialArtists;

  @Watch('$route')
  private async onRouteChanged() {
    this.artists = initialArtists;
    await this.fetchData();
  }

  private async created() {
    this.fetchData();
  }

  private async fetchData() {
    try {
      const response = await Axios.get(`/api/shows/${this.showId}/guests`);
      this.artists = response.data;
    } catch (e) {
      this.error('Something went wrong!');
    }
  }

}
</script>
