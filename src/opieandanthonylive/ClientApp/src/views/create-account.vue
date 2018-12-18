<template>
  <v-container fluid fill-height>
    <v-layout align-center justify-center>
      <v-flex xs12 sm8 md6 lg4>

        <v-card raised class="create-account">
          <v-form ref="form" v-model="valid" @submit.prevent="submit">
            <v-card-text>
              <v-text-field required v-model="username"        prepend-icon="mdi-account" :rules="usernameRules" label="Username" />
              <v-text-field required v-model="email"           prepend-icon="mdi-email"   :rules="emailRules"    label="E-mail"   />
              <v-text-field required v-model="password"        prepend-icon="mdi-lock"    :rules="passwordRules" label="Password" type="password"/>
              <v-text-field required v-model="confirmPassword" prepend-icon="mdi-lock"    :error-messages="passwordMatchError" type="password" label="Confirm password"/>
            </v-card-text>

            <v-card-actions>
              <v-flex>
                <p class="error--text">{{ serverValidation }}</p>
              </v-flex>
              <v-btn color="primary" @click="submit" :loading="isBusy">submit</v-btn>
            </v-card-actions>

          </v-form>
        </v-card>

      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">

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
