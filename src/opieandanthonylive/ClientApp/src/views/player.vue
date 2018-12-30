<template>
  <v-container grid-list-lg>
    <v-layout row justify-center wrap>
      <v-flex xs12 sm6>
        <v-responsive :aspect-ratio="1/1">
          <v-img :src="'http://opieandanthonylive.info/alpha3/images/Mishna Wolff.jpg'" />
        </v-responsive>
      </v-flex>
      <v-flex x12 sm6>
        <timeline />
        <player-controls style="margin: 0 10px;"/>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import PlayerControls from '@/components/media-player/controls.vue';
import Timeline from '@/components/media-player/timeline.vue';

@Component({
  components: {
    PlayerControls,
    Timeline,
  },
})
export default class Player extends Vue {
}
</script>
