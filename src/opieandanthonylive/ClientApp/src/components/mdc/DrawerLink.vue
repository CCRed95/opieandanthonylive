<template>
  <router-link :to="to" class="mdc-list-item" tabindex="0" aria-selected="true">
    <i class="material-icons mdc-list-item__graphic" aria-hidden="true">
      {{ icon }}
    </i>
    <slot />
  </router-link>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component
export default class DrawerLink extends Vue {
  @Prop(String) public icon!: string;
  @Prop(String) public to!: string;
}
</script>