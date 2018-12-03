<template>
  <div class="create-account-container">
    <v-card raised class="create-account">
      <v-form v-model="valid">
        <v-card-text>

          <v-text-field v-model="username"        :rules="nameRules"     label="Username"         required />
          <v-text-field v-model="email"           :rules="emailRules"    label="E-mail"           required />
          <v-text-field v-model="password"        :rules="passwordRules" label="Password"         required />
          <v-text-field v-model="confirmPassword" :rules="passwordRules" label="Confirm password" required />
        </v-card-text>

        <v-card-actions>
          <v-spacer />
          <v-btn color="primary">submit</v-btn>
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
  margin-left: auto;
  margin-right: auto;
  margin-top: auto;
  margin-bottom: auto;
  padding: 10px 25px 25px 25px;
}
</style>


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
