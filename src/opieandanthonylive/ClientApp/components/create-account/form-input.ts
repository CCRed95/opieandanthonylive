import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

export interface FormInput {
  type:        string;
  placeholder: string;
  errors:      string[];
}

@Component
export default class FormInputComponent extends Vue {

  constructor() {
    super();
  }

  @Prop({ type: Object as () => FormInput })
  data!: FormInput;

  get hasErrors() {
    return this.data.errors.length > 0;
  }

}
