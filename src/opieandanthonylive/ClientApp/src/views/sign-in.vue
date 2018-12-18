<template>

  <v-container fluid fill-height>
    <v-layout align-center justify-center>

      <v-flex xs12 sm8 md6 lg4>
        <v-card raised>
          <v-form ref="form" @submit.prevent="submit">
            <v-card-text class="sign-in-fields">
              <v-text-field v-model="username" label="Username" required prepend-icon="mdi-account" />
              <v-text-field v-model="password" label="Password" required prepend-icon="mdi-lock" type="password" />
            </v-card-text>

            <v-card-actions>
              <v-flex>
                <p class="error--text">{{ serverValidation }}</p>
              </v-flex>
              <v-btn color="primary" @click="submit" :loading="isBusy">Submit</v-btn>
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

import { LoginPayload } from '@/store/auth';
import { authRoutes } from '@/router';

const auth = namespace('auth');
const route = namespace('route');

@Component
export default class SignIn extends Vue {

  @auth.Action('login')
  public signInAction!: (payload: LoginPayload) => Promise<any>;

  @route.State('from')
  public prevRoute!: Route;

  public isBusy: boolean = false;
  public serverValidation: string = '';

  public username: string = '';
  public password: string = '';

  public async submit() {
    try {
      this.isBusy = true;

      await this.signInAction({
        username: this.username,
        password: this.password,
      });

      authRoutes.find((s) => this.prevRoute.path === s)
        ? this.$router.replace('/')
        : this.$router.replace(this.prevRoute.path);
    } catch (e) {
      this.serverValidation = e.kind === 'login-error'
        ? 'Incorrect username or password'
        : 'Unknown error occurred';
    } finally {
      this.isBusy = false;
    }

  }

}
</script>
