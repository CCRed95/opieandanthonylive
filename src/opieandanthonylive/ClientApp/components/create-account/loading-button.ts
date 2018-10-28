import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component
export default class LoadingButtonComponent extends Vue {
  @Prop(Boolean) isLoading!: boolean;
}