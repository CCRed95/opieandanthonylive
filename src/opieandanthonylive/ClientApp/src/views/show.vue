<template>
  <div>
    <h2 class="display-3">O&A</h2>

    <v-tabs color="transparent" slider-color="primary">
      <v-tab ripple to="by-artist">By Artist</v-tab>
      <v-tab ripple to="by-date">By Date</v-tab>
      <v-tab ripple to="by-timeline">By Timeline</v-tab>
    </v-tabs>

    <router-view />

  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

import GuestCards from '@/components/guest-cards.vue';

@Component({
  components: {
    GuestCards,
  },
})
export default class Show extends Vue {
}
</script>
