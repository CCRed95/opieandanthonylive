import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { namespace } from 'vuex-class';

const auth = namespace('auth');

@Component
export default class NavbarComponent extends Vue {
  @auth.Getter('isSignedIn') isSignedIn!: boolean;
  @auth.Getter('username') username!: string;
}