<template>
  <div class="create-account-container">
    <v-card raised class="create-account">
      <v-form ref="form" v-model="valid" @submit.prevent="submit">
        <v-card-text>
          <v-text-field
            v-model="username"
            :rules="usernameRules"
            label="Username"
            required />
          <v-text-field
            v-model="email"
            :rules="emailRules"
            label="E-mail"
            required />
          <v-text-field
            v-model="password"
            :rules="passwordRules"
            type="password"
            label="Password"
            required />
          <v-text-field
            v-model="confirmPassword"
            :error-messages="passwordMatchError"
            type="password"
            label="Confirm password"
            required />
        </v-card-text>

        <v-card-actions>
          <p class="server-validation error--text">{{ serverValidation }}</p>
          <v-btn color="primary" @click="submit" :loading="isBusy">submit</v-btn>
        </v-card-actions>

      </v-form>
    </v-card>
  </div>
</template>

<style>
.create-account-container {
  display: flex;
  height: 100%;
}

.create-account {
  width: 500px;
  max-width: 90vw;
  margin: auto;
  padding: 10px 25px 25px 25px;
}

.server-validation {
  flex: 1;
}
</style>


<script lang="ts">
// tslint:disable:typedef-whitespace

import Vue from 'vue';
import { namespace } from 'vuex-class';
import { Component } from 'vue-property-decorator';
import { Route } from 'vue-router';

import { validEmail } from '@/util';
import { RegisterPayload } from '@/store/auth';
import { authRoutes } from '@/router';

const auth = namespace('auth');
const route = namespace('route');

@Component
export default class CreateAccount extends Vue {

  @auth.Action('register')
  public submitAction!: (payload: RegisterPayload) => Promise<any>;

  @route.State('from')
  public prevRoute!: Route;

  public valid: boolean = false;
  public isBusy: boolean = false;
  public serverValidation: string = '';

  public username:        string = '';
  public email:           string = '';
  public password:        string = '';
  public confirmPassword: string = '';

  public usernameRules = [
    (v: string) => !!v || 'Username is required',
  ];

  public emailRules = [
    (v: string) => !!v           || 'Email is required',
    (v: string) => validEmail(v) || 'Email must be valid',
  ];

  public passwordRules = [
    (v: string) => !!v           || 'Password is required',
    (v: string) => v.length >= 6 || 'Password must have at least 6 characters',
  ];

  get passwordMatchError() {
    return this.password === this.confirmPassword ? [] : ['Passwords must match'];
  }

  public async submit() {
    (this.$refs.form as any).validate();

    if (this.valid === false) {
      return;
    }

    try {
      this.isBusy = true;

      await this.submitAction({
        email: this.email,
        username: this.username,
        password: this.password,
      });

      authRoutes.find((s) => this.prevRoute.path === s)
        ? this.$router.replace('/')
        : this.$router.replace(this.prevRoute.path);
    } catch (e) {
      this.serverValidation = e.kind === 'username-already-exists'
        ? `Username '${e.username}' already taken`
        : 'Unknown error occurred';
    } finally {
      this.isBusy = false;
    }

  }

}
</script>
