<template>

  <div
    ref="root"
    :class="rootClasses">

    <input
      ref="input"
      :id="id"
      :type="type"
      class="mdc-text-field__input">

    <label
      v-if="hasLabel"
      ref="label"
      :class="labelClasses"
      :for="id">
      {{ label }}
    </label>

    <div
      class="mdc-line-ripple">
    </div>

  </div>

</template>


<script lang="ts">
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { MDCFloatingLabelFoundation } from '@material/floating-label';
import { MDCTextFieldFoundation } from '@material/textfield';

@Component
export default class TextField extends Vue {

  @Prop(String) public id?: string;
  @Prop(String) public type?: string;
  @Prop(String) public label?: string;

  public rootClasses: any = {
    'mdc-text-field': true,
  };

  public labelClasses: any = {
    'mdc-floating-label': true,
  };

  private foundation: any;
  private labelFoundation: any;

  public mounted() {
    if (this.hasLabel) {
      this.labelFoundation = new MDCFloatingLabelFoundation(this.labelAdapter);
      this.labelFoundation.init();
    }

    this.foundation = new MDCTextFieldFoundation(this.adapter);
    this.foundation.init();
  }

  public beforeDestroy() {
    this.foundation.destroy();

    if (this.labelFoundation) {
      this.labelFoundation.destroy();
    }
  }

  private get hasLabel(): boolean {
    return !!this.label;
  }

  private get labelAdapter() {
    const self = this;
    return {

      addClass:    (className: string) => self.$set(self.labelClasses, className, true),
      removeClass: (className: string) => self.$delete(self.labelClasses, className),

      getWidth: () =>
        (this.$refs.label as HTMLElement).offsetWidth,

      registerInteractionHandler: (evtType: string, handler: (ev: Event) => undefined) =>
        (this.$refs.label as Element).addEventListener(evtType, handler),

      deregisterInteractionHandler: (evtType: string, handler: (ev: Event) => undefined) =>
        (this.$refs.label as Element).removeEventListener(evtType, handler),

    };
  }

  private get adapter() {
    const self = this;
    return {

      addClass:    (className: string) => self.$set(self.rootClasses, className, true),
      removeClass: (className: string) => self.$delete(self.rootClasses, className),
      hasClass:    (className: string) => className in self.rootClasses,

      registerTextFieldInteractionHandler: (type: string, handler: (ev: Event) => undefined) =>
        (self.$refs.root as Element).addEventListener(type, handler),

      deregisterTextFieldInteractionHandler: (type: string, handler: (ev: Event) => undefined) =>
        (self.$refs.root as Element).removeEventListener(type, handler),

      registerInputInteractionHandler: (evtType: string, handler: (ev: Event) => undefined) =>
        (self.$refs.input as Element).addEventListener(evtType, handler),

      deregisterInputInteractionHandler: (evtType: string, handler: (ev: Event) => undefined) =>
        (self.$refs.input as Element).removeEventListener(evtType, handler),

      registerValidationAttributeChangeHandler: (handler: (attributes: string[]) => undefined): MutationObserver => {

        const getAttributeNames = (mutations: MutationRecord[]): string[] =>
          mutations.filter((x) => x !== null).map((x) => x.attributeName) as string[];

        const observer = new MutationObserver((mutations) =>
          handler(getAttributeNames(mutations)));

        observer.observe(this.$refs.input as Element, { attributes: true });

        return observer;

      },

      deregisterValidationAttributeChangeHandler: (observer: MutationObserver) =>
        observer.disconnect(),

      getNativeInput: () =>
        self.$refs.input as Element,

      isFocused: () =>
        document.activeElement === self.$refs.input,

      isRtl: () =>
        'rtl' === window
          .getComputedStyle(self.$refs.root as Element)
          .getPropertyValue('direction'),

      activateLineRipple: () => { /* TODO */ },

      /**
       * Deactivates the line ripple.
       */
      deactivateLineRipple: () => { /* TODO */ },

      /**
       * Sets the transform origin of the line ripple.
       * @param {number} normalizedX
       */
      setLineRippleTransformOrigin: (normalizedX: number) => { /* TODO */ },

      hasLabel: () =>
        this.hasLabel,

      shakeLabel: (shouldShake: boolean) =>
        self.labelFoundation.shake(shouldShake),

      floatLabel: (shouldFloat: boolean) =>
        this.labelFoundation.float(shouldFloat),

      getLabelWidth: () =>
        this.labelFoundation.getWidth(),

      /**
       * Returns true if outline element exists, false if it doesn't.
       * @return {boolean}
       */
      hasOutline: () => { /* TODO */ },

      /**
       * Only implement if outline element exists.
       * Updates SVG Path and outline element based on the
       * label element width and RTL context.
       * @param {number} labelWidth
       * @param {boolean=} isRtl
       */
      notchOutline: (labelWidth: number, isRtl: boolean) => { /* TODO */ },

      /**
       * Only implement if outline element exists.
       * Closes notch in outline element.
       */
      closeOutline: () => { /* TODO */ },

    };

  }

}
</script>
