<template>
  <div style="min-height: 100vh;">

    <mdc-drawer ref="drawer">

      <div class="mdc-drawer__header">
        <h3 class="mdc-drawer__title">opieandanthonylive</h3>
      </div>

      <div class="mdc-drawer__content">
        <nav class="mdc-list">
          <mdc-drawer-link icon="home" to="/">Home</mdc-drawer-link>
          <mdc-list-divider/>
          <mdc-drawer-link icon="account_circle" to="/sign-in">Sign in</mdc-drawer-link>
          <mdc-drawer-link icon="account_circle" to="/create-account">Create account</mdc-drawer-link>
        </nav>
      </div>

    </mdc-drawer>

    <mdc-top-app-bar title="opieandanthonylive" @navigation-clicked="$refs.drawer.open()"/>

    <div style="max-width: 1140px; margin-left: auto; margin-right: auto; text-align: center;">
      <router-view class="mdc-top-app-bar--fixed-adjust" />
    </div>

    <footer style="position: fixed; bottom: 0; width: 100%;">
      <media-player />
    </footer>

  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import MdcDrawer from '@/components/mdc/Drawer';
import MdcDrawerLink from '@/components/mdc/DrawerLink.vue';
import MdcListDivider from '@/components/mdc/ListDivider.vue';
import MdcTopAppBar from '@/components/mdc/TopAppBar';
import MediaPlayer from '@/components/media-player/media-player';

@Component({
  components: {
    MdcDrawer,
    MdcDrawerLink,
    MdcListDivider,
    MdcTopAppBar,
    MediaPlayer,
  },
})
export default class App extends Vue {
}
</script>