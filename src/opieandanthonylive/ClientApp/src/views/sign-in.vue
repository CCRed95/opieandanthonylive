<template>
  <div class="sign-in-container">
    <v-card raised class="sign-in">
      <v-form ref="form" @submit.prevent="submit">

        <v-card-text class="sign-in-fields">
          <v-text-field
            v-model="username"
            :rules="usernameRules"
            label="Username"
            required />
          <v-text-field
            v-model="password"
            :rules="passwordRules"
            type="password"
            label="Password"
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
.sign-in-container {
  display: flex;
  height: 100%;
}

.sign-in {
  width: 500px;
  max-width: 90vw;
  margin: auto;
  padding: 10px 25px 25px 25px;
}

.sign-in-fields {
  height: 250px;
  max-height: 80vh;
}

.server-validation {
  flex: 1;
}
</style>

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
