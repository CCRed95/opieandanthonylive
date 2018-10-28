import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

export type InputType
  = "text"
  | "email"
  | "password";

export interface FormInput {
  id:          number;
  type:        InputType;
  placeholder: string;
  value:       string;
  errors:      string[];
}

export const mkInput = (id: number, type: InputType, placeholder: string): FormInput => ({
  id,
  type,
  placeholder,
  value: "",
  errors: []
});

export interface FormValidation<TModel> {
  input: (m: TModel) => FormInput;
  validation: (m: TModel, v: string) => string[];
}

export const mkFormValidation = <TModel>(
  input: (m: TModel) => FormInput,
  p: (m: TModel, s: string) => boolean,
  error: string
): FormValidation<TModel> => ({
  input,
  validation: (m, v) => p(m, v) ? [error] : []
});

@Component
export default class FormInputComponent extends Vue {

  @Prop({ type: Object as () => FormInput }) vm!: FormInput;

  get hasErrors() {
    return this.vm.errors.length > 0;
  }

}
