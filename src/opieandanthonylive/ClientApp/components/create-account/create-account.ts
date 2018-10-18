import { namespace } from 'vuex-class';

import { validEmail } from '../../helpers';
import { FormInput, mkInput, FormValidation, mkFormValidation } from './form-input';
import { RegisterPayload, RegistrationError } from '../../store/auth';
import { AuthForm, FormComponent } from './auth-form';

const auth = namespace('auth');

interface CreateAccountModel {
  username:        FormInput;
  email:           FormInput;
  password:        FormInput;
  passwordConfirm: FormInput;
}

@FormComponent
export default class CreateAccountComponent extends
  AuthForm<CreateAccountModel, RegistrationError, RegisterPayload>
{

  constructor() {
    super({
      username:        mkInput(1, 'text',     'Username'),
      email:           mkInput(2, 'email',    'Email'),
      password:        mkInput(3, 'password', 'Password'),
      passwordConfirm: mkInput(4, 'password', 'Confirm password'),
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