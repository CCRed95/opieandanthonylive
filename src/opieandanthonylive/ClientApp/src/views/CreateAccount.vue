<template>
  <v-card raised class="mt-4" style="max-width: 500px; margin-left: auto; margin-right: auto;">
    <v-form v-model="valid">

      <v-card-title class="text-md-center">
        <h5 class="headline">Create account</h5>
      </v-card-title>

      <v-card-text>

        <v-text-field
          v-model="username"
          :rules="nameRules"
          label="Name"
          required />

        <v-text-field
          v-model="email"
          :rules="emailRules"
          label="E-mail"
          required />

        <v-text-field
          v-model="password"
          :rules="passwordRules"
          label="Password"
          required />

        <v-text-field
          v-model="confirmPassword"
          :rules="passwordRules"
          label="Confirm password"
          required />

      </v-card-text>

      <v-card-actions>
        <v-btn color="primary">Submit</v-btn>
      </v-card-actions>

    </v-form>
  </v-card>
</template>

<script lang="ts">
// tslint:disable:typedef-whitespace

import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class CreateAccount extends Vue {

  public username:        string = '';
  public email:           string = '';
  public password:        string = '';
  public confirmPassword: string = '';

}
</script>