<template>
  <div class="slider-wrapper" ref="sliderWrapper" @mousedown.prevent="beginDragging">
    <div class="slider-center-wrapper">
      <div class="slider-background secondary"></div>
      <div class="slider-value primary"            :style="{ width: valueFmt }"></div>
      <div class="slider-handle primary lighten-1" :style="{ left: valueFmt }" v-if="hasHandle"></div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { clamp, drag } from '@/util';

@Component
export default class Slider extends Vue {

  @Prop(Number)            public value!: number;
  @Prop({ default: true }) public hasHandle!: boolean;

  private dragValue: number = 0.0;
  private isDragging: boolean = false;

  public get valueFmt() {
    return `${(this.isDragging ? this.dragValue : this.value) * 100}%`;
  }

  public beginDragging(event: MouseEvent) {
    const div = this.$refs.sliderWrapper as HTMLDivElement;

    const onMove = (ev: MouseEvent) => {
      const width = div.clientWidth;
      const left = div.getBoundingClientRect().left;
      const offset = clamp(0, ev.clientX - left, width);
      this.dragValue = offset / width;
      this.$emit('dragging', this.dragValue);
    };

    const onGrab = () => { this.isDragging = true; onMove(event); this.$emit('drag'); };
    const onDrop = () => {
      this.isDragging = false;
      this.$emit('dragged', this.value);
    };

    drag(onGrab, onMove, onDrop);
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
  height: 10px;
  width: 10px;
  border-radius: 50%;
  position: absolute;
  transform: translate(-50%, -50%);
}

</style>
