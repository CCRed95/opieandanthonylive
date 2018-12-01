<template>
  <button class="btn" :disabled="isLoading">
    <i v-show="isLoading" class="fas fa-circle-notch fa-spin"></i>
    <slot/>
  </button>
</template>
