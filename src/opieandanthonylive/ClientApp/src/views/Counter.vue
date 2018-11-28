<template>
  <div>
    <h1>Counter</h1>
    <p>This is a simple example of a Vue.js component.</p>
    <p>Current count: <strong>{{ currentcount }}</strong></p>
    <button @click="incrementCounter" class="btn btn-primary">Increment</button>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class CounterComponent extends Vue {
  private currentcount = 0;

  public incrementCounter() {
    this.currentcount++;
  }
}
</script>