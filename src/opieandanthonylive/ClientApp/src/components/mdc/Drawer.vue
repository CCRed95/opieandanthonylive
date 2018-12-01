<template>
  <div>
    <aside class="mdc-drawer mdc-drawer--modal" :class="classes" ref="drawer" @transitionend="transitionEnd">
      <slot />
    </aside>
    <div class="mdc-drawer-scrim" @click="close()"></div>
  </div>
</template>

<script src="./Drawer.ts"></script>