import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

import { flattenArray, validEmail } from '../../helpers';
import { FormInput, mkInput } from './form-input';
import { RegisterPayload, RegistrationError } from '../../store/auth';
import { VueClass } from 'vue-class-component/lib/declarations';

interface FormValidation<TModel> {
  input: (m: TModel) => FormInput;
  validation: (m: TModel, v: string) => string[];
}

const mkFormValidation = <TModel>(
  input: (m: TModel) => FormInput,
  p: (m: TModel, s: string) => boolean,
  error: string
): FormValidation<TModel> => ({
  input,
  validation: (m, v) => p(m, v) ? [error] : []
});

const auth = namespace('auth');

const FormComponent = <V extends Vue, VC extends VueClass<V>>(x: VC): VC =>
  Component({
    components: {
      'form-input': require('./form-input.vue.html').default,
      'loading-button': require('./loading-button.vue.html').default
    }
  })(x);

abstract class AuthFormComponent<TModel, TServerError, TPayload> extends Vue {

  constructor(readonly model: TModel, getInputs: (m: TModel) => FormInput[]) {
    super();
    this.inputs = getInputs(model);
  }

  @Prop({ type: Object as () => FormInput[] })
  readonly inputs: FormInput[];

  @Prop(Boolean)
  isBusy!: boolean;

  @Prop(String)
  serverValidation!: string;

  protected handleSubmit(): void {

    this.validate();

    // stop on errors
    if (flattenArray(this.inputs.map(x => x.errors)).length > 0)
      return;

    this.isBusy = true;

    this.submit(this.createPayload(this.model))
      .catch((e: TServerError) => this.serverValidation = this.formatError(e))
      .then(_ => this.isBusy = false);

  }

  private validate() {
    for (const v of this.validations) {
      const input = v.input(this.model);
      input.errors = v.validation(this.model, input.value);
    }
  }

  abstract validations: FormValidation<TModel>[];
  abstract createPayload: (m: TModel) => TPayload;
  abstract submit: (payload: TPayload) => Promise<any>;
  abstract formatError(e: TServerError): string;

}

interface CreateAccountModel {
  username:        FormInput;
  email:           FormInput;
  password:        FormInput;
  passwordConfirm: FormInput;
}

@FormComponent
export default class CreateAccountComponent extends
  AuthFormComponent<CreateAccountModel, RegistrationError, RegisterPayload>
{

  constructor() {
    super({
      username:        mkInput('text',     'Username'),
      email:           mkInput('email',    'Email'),
      password:        mkInput('password', 'Password'),
      passwordConfirm: mkInput('password', 'Confirm password'),
    }, m => [m.username, m.email, m.password, m.passwordConfirm]);
  }

  validations: FormValidation<CreateAccountModel>[] = [
      mkFormValidation(m => m.username, (_, s) => s.length == 0, "Please provide a username"),
      mkFormValidation(m => m.email, (_, s) => validEmail(s) == false, "Please provide a valid email address"),
      mkFormValidation(m => m.password, (_, s) => s.length < 6, "Password must contain at least 6 characters"),
      mkFormValidation(m => m.passwordConfirm, (m, s) => s != m.password.value, "Passwords must match"),
  ];

  createPayload = (m: CreateAccountModel): RegisterPayload => ({
      email:    m.email.value,
      username: m.username.value,
      password: m.password.value,
  });

  @auth.Action('register')
  submit!: (payload: RegisterPayload) => Promise<any>;

  formatError(x: RegistrationError) {
    return x.kind == "username-already-exists"
      ? `Username '${x.username}' already taken`
      : 'Unknown error occurred';
  }

}