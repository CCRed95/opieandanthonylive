import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
  components: {
    'controls': require('./controls.vue.html').default,
    'timeline': require('./timeline.vue.html').default,
    'volume-control': require('./volume-control.vue.html').default,
    'badge': require('./badge.vue.html').default,
    'playlist': require('./playlist.vue.html').default,
  }
})
export default class MediaPlayerComponent extends Vue {
}