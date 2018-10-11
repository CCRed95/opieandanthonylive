import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import { flattenArray, validEmail } from '../../helpers';
import { FormInput, InputType } from './form-input';
import { RegisterPayload } from '../../store/auth';

type Validation = (value: string) => string[];

interface ValidatedInput {
  input: FormInput;
  validation: Validation;
}

const mkValidation = (p: (s: string) => boolean, error: string): Validation =>
  i => p(i) ? [error] : [];

const mkValidatedInput = (type: InputType, placeholder: string, ...validations: Validation[]): ValidatedInput => {
  const input = { type, placeholder, value: "", errors: [] };
  const validation = (i: string) => flattenArray(validations.map(v => v(i)));
  return { input, validation };
}

const auth = namespace('auth');

@Component({
  components: {
    'form-input': require('./form-input.vue.html').default
  }
})
export default class CreateAccountComponent extends Vue {

  readonly username = mkValidatedInput('text', 'Username',
      mkValidation(s => s.length == 0, "Please provide a username"));

  readonly email = mkValidatedInput('email', 'Email',
    mkValidation(s => validEmail(s) == false, "Please provide a valid email address"));

  readonly password = mkValidatedInput('password', 'Password',
    mkValidation(s => s.length < 6, "Password must contain at least 6 characters"));

  readonly passwordConfirm = mkValidatedInput('password', 'Confirm password',
    mkValidation(s => s != this.password.input.value, "Passwords must match"));

  readonly validatedInputs = [this.username, this.email, this.password, this.passwordConfirm];

  @Prop({ type: Object as () => FormInput[] })
  inputs: FormInput[] = this.validatedInputs.map(x => x.input);

  @auth.Action('register')
  register!: (payload: RegisterPayload) => void;

  submit() {

    this.validatedInputs.forEach(x =>
      x.input.errors = x.validation(x.input.value));

    // stop on errors
    if (flattenArray(this.inputs.map(x => x.errors)).length > 0)
      return;

    this.register({
      email:    this.email.input.value,
      username: this.username.input.value,
      password: this.password.input.value,
    });

  }

}