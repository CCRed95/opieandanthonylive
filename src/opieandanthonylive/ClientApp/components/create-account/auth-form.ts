import Vue from 'vue';
import { Prop, Component } from 'vue-property-decorator';
import { VueClass } from 'vue-class-component/lib/declarations';
import { namespace } from 'vuex-class';
import { Route } from 'vue-router';

import { FormInput, FormValidation } from './form-input';
import { flattenArray } from '../../helpers';
import { authRoutes } from '../../router';

const route = namespace('route');

export const FormComponent = <V extends Vue, VC extends VueClass<V>>(x: VC): VC =>
  Component({
    components: {
      'form-input': require('./form-input.vue.html').default,
      'loading-button': require('./loading-button.vue.html').default
    }
  })(x);

export abstract class AuthForm<TModel, TServerError, TPayload> extends Vue {

  constructor(readonly model: TModel, getInputs: (m: TModel) => FormInput[]) {
    super();
    this.inputs = getInputs(model);
  }

  @Prop({ type: Object as () => FormInput[] })
  readonly inputs: FormInput[];

  @Prop(Boolean) isBusy!: boolean;
  @Prop(String) serverValidation!: string;

  @route.State('from') prevRoute!: Route;

  protected async handleSubmit(): Promise<void> {

    this.validate();

    // stop on errors
    if (flattenArray(this.inputs.map(x => x.errors)).length > 0)
      return;

    this.isBusy = true;

    try {
      await this.submit(this.createPayload(this.model))

      authRoutes.find(s => this.prevRoute.path == s)
        ? this.$router.replace('/')
        : this.$router.replace(this.prevRoute.path);

    } catch (e) {
      this.serverValidation = this.formatError(e);
    }

    this.isBusy = false;

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
