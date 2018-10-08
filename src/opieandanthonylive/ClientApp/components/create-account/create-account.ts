import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

import { FormInput } from './form-input';

@Component({
  components: {
    'form-input': require('./form-input.vue.html').default
  }
})
export default class CreateAccountComponent extends Vue {

  @Prop({ type: Object as () => FormInput[] })
  inputs: FormInput[] = [
    {
      type: 'text',
      placeholder: 'Username',
      errors: [],
    },
    {
      type: 'email',
      placeholder: 'Email',
      errors: [],
    },
    {
      type: 'password',
      placeholder: 'Password',
      errors: [],
    },
    {
      type: 'password',
      placeholder: 'Confirm password',
      errors: [],
    },
  ];

  submit() {
    alert();
  }

}
