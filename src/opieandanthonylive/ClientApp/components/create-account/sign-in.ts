import { namespace } from 'vuex-class';

import { FormInput, mkInput, FormValidation, mkFormValidation } from './form-input';
import { RegistrationError, LoginPayload, LoginError } from '../../store/auth';
import { AuthForm, FormComponent } from './auth-form';

const auth = namespace('auth');

interface LoginModel {
  username: FormInput;
  password: FormInput;
}

@FormComponent
export default class CreateAccountComponent extends
  AuthForm<LoginModel, RegistrationError, LoginPayload>
{
  constructor() {
    super({
      username: mkInput(1, 'text',     'Username'),
      password: mkInput(2, 'password', 'Password'),
    }, m => [m.username, m.password]);
  }

  validations: FormValidation<LoginModel>[] = [
      mkFormValidation(m => m.username, (_, s) => s.length == 0, "Please provide a username"),
      mkFormValidation(m => m.password, (_, s) => s.length < 6, "Password must contain at least 6 characters"),
  ];

  createPayload = (m: LoginModel): LoginPayload => ({
      username: m.username.value,
      password: m.password.value,
  });

  @auth.Action('login')
  submit!: (payload: LoginPayload) => Promise<any>;

  formatError(x: LoginError) {
    return x.kind == 'login-error'
      ? 'Invalid username or password'
      : 'Unknown error occurred';
  }

}
