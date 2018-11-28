import Vue from 'vue';
import { Component } from 'vue-property-decorator';

import Controls from './controls';
import Timeline from './timeline';
import VolumeControl from './volume-control';
import Badge from './badge';
import Playlist from './playlist';

@Component({
  components: {
    Controls,
    Timeline,
    VolumeControl,
    Badge,
    Playlist,
  },
})
export default class MediaPlayerComponent extends Vue {
}
