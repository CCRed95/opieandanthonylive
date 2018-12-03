<template>
  <v-form v-model="valid">
    <v-text-field v-model="username"        :rules="nameRules"     label="Name"             required />
    <v-text-field v-model="email"           :rules="emailRules"    label="E-mail"           required />
    <v-text-field v-model="password"        :rules="passwordRules" label="Password"         required />
    <v-text-field v-model="confirmPassword" :rules="passwordRules" label="Confirm password" required />
    <v-btn color="primary">Submit</v-btn>
  </v-form>
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