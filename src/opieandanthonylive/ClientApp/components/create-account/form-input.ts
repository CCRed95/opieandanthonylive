import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

export type InputType
  = "text"
  | "email"
  | "password";

export interface FormInput {
  type:        InputType;
  placeholder: string;
  value:       string;
  errors:      string[];
}

export const mkInput = (type: InputType, placeholder: string): FormInput => ({
  type,
  placeholder,
  value: "",
  errors: []
});

@Component
export default class FormInputComponent extends Vue {

  @Prop({ type: Object as () => FormInput }) vm!: FormInput;

  get hasErrors() {
    return this.vm.errors.length > 0;
  }

}
