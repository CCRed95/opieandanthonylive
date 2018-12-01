<template>
  <header class="mdc-top-app-bar">
    <div class="mdc-top-app-bar__row">
      <section class="mdc-top-app-bar__section mdc-top-app-bar__section-align-start">
        <a href="#" class="material-icons mdc-top-app-bar__navigation-icon" @click="$emit('navigation-clicked')">menu</a>
        <span class="mdc-top-app-bar__title">{{ title }}</span>
      </section>
    </div>
  </header>
</template>

<script src="./TopAppBar.ts"></script>