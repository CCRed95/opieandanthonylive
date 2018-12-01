<template>
  <div>

    <mdc-h4>Create account</mdc-h4>

    <form @submit.prevent="handleSubmit" novalidate>
      <mdc-text-field />
      <br/>
      <mdc-text-field />
      <br/>
      <mdc-text-field />
      <br/>
      <mdc-text-field />
    </form>

    <div class="">
      alert
    </div>

  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import MdcH4 from '@/components/mdc/H4.vue';
import MdcSubtitle1 from '@/components/mdc/Subtitle1.vue';
import MdcTextField from '@/components/mdc/TextField.vue';

@Component({
  components: {
    MdcH4,
    MdcSubtitle1,
    MdcTextField,
  },
})
export default class CreateAccount extends Vue {
}
</script>