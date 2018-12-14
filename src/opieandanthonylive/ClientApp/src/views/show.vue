<template>
  <div>
    <h1 class="display-4">O&A</h1>

    <v-tabs color="transparent" slider-color="primary">
      <v-tab ripple>By Artist</v-tab>
      <v-tab-item>
        <v-container grid-list-xl fluid>
          <v-layout row wrap>
            <v-flex xs6 sm3 md2 v-for="i in 12" :key="i">
              <guest-card image="http://opieandanthonylive.info/alpha3/images/Jim%20Norton.jpg" name="Jim Norton" :nShows="763" />
            </v-flex>
          </v-layout>
        </v-container>
      </v-tab-item>

      <v-tab ripple>By Date</v-tab>
      <v-tab-item>Tab-B</v-tab-item>

      <v-tab ripple>By Timeline</v-tab>
      <v-tab-item>Tab-C</v-tab-item>

    </v-tabs>

  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

import GuestCard from '@/components/guest-card.vue';

@Component({
  components: {
    GuestCard,
  },
})
export default class Show extends Vue {
}
</script>
