import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

import { FormInput, InputType } from './form-input';

const flatten = <T>(xs: T[]) =>
  [].concat.apply([], xs);

const validEmail = (email: string) => {
  const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  return re.test(email);
}

type Validation = (value: string) => string[];

interface ValidatedInput {
  input: FormInput;
  validation: Validation;
}

const mkValidation = (p: (s: string) => boolean, error: string): Validation =>
  i => p(i) ? [error] : [];

const mkInput = (type: InputType, placeholder: string, ...validations: Validation[]): ValidatedInput => {
  const input = { type, placeholder, value: "", errors: [] };
  const validation = (i: string) => flatten(validations.map(v => v(i)));
  return { input, validation };
}

@Component({
  components: {
    'form-input': require('./form-input.vue.html').default
  }
})
export default class CreateAccountComponent extends Vue {

  readonly username = mkInput('text', 'Username',
      mkValidation(s => s.length == 0, "Please provide a username"));

  readonly email = mkInput('email', 'Email',
    mkValidation(s => validEmail(s) == false, "Please provide a valid email address"));

  readonly password = mkInput('password', 'Password',
    mkValidation(s => s.length < 6, "Password must contain at least 6 characters"));

  readonly passwordConfirm = mkInput('password', 'Confirm password',
    mkValidation(s => s != this.password.input.value, "Passwords must match"));

  readonly validatedInputs = [this.username, this.email, this.password, this.passwordConfirm];

  @Prop({ type: Object as () => FormInput[] })
  inputs: FormInput[] = this.validatedInputs.map(x => x.input);

  submit() {

    this.validatedInputs.forEach(x =>
      x.input.errors = x.validation(x.input.value));

    if (flatten(this.inputs.map(x => x.errors)).length > 0) {
    }

  }

}