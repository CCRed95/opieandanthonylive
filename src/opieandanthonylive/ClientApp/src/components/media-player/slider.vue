<template>
  <div class="slider-wrapper">
    <div class="slider-center-wrapper">
      <div class="slider-background secondary"></div>
      <div class="slider-value primary"            :style="{ width: valueFmt }"></div>
      <div class="slider-handle primary lighten-1" :style="{ left: valueFmt }"></div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class Slider extends Vue {

  private value: number = 0.5;

  public get valueFmt() {
    return `${this.value * 100}%`;
  }

}
</script>

<style>

.slider-wrapper {
  display: block;
  padding: 20px 0;
}

.slider-center-wrapper {
  position: relative;
}

.slider-wrapper:hover {
  cursor: pointer;
}

.slider-background {
  position: absolute;
  height: 4px;
  border-radius: 4px;
  width: 100%;
  transform: translateY(-50%);
}

.slider-value {
  position: absolute;
  height: 4px;
  border-radius: 4px;
  transform: translateY(-50%);
}

.slider-handle {
  height: 12px;
  width: 12px;
  border-radius: 50%;
  position: absolute;
  transform: translateX(-50%) translateY(-50%);
}

</style>
