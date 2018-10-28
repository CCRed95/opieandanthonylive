import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
  components: {
    'navbar': require('../navbar/navbar.vue.html').default,
    'media-player': require('../media-player/media-player.vue.html').default
  }
})
export default class AppComponent extends Vue {
}
