<template>

  <div
    ref="root"
    :class="rootClasses">

    <input
      ref="input"
      type="text"
      id="my-text-field"
      class="mdc-text-field__input">

    <label
      ref="label"
      class="mdc-floating-label"
      for="my-text-field">
      Hint text
    </label>

    <div
      class="mdc-line-ripple">
    </div>

  </div>

</template>


<script lang="ts">
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { MDCTextFieldFoundation } from '@material/textfield';

@Component
export default class TextField extends Vue {

  public rootClasses: any = {
    'mdc-text-field': true,
  };

  private foundation: any;
  private previousFocus: any;

  public mounted() {
    this.foundation = new MDCTextFieldFoundation(this.adapter);
    this.foundation.init();
  }

  public beforeDestroy() {
    this.foundation.destroy();
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

      /**
       * Registers a validation attribute change listener on the input element.
       * Handler accepts list of attribute names.
       * @param {function(!Array<string>): undefined} handler
       * @return {!MutationObserver}
       */
      registerValidationAttributeChangeHandler: (handler: (attributes: string[]) => undefined): MutationObserver => {
        const observer = new MutationObserver((mutations) => {
          const attributes = mutations
            .filter((x) => x !== null)
            .map((x) => x.attributeName) as string[];
          handler(attributes);
        });

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

      /**
       * Only implement if label exists.
       * Shakes label if shouldShake is true.
       * @param {boolean} shouldShake
       */
      shakeLabel: (shouldShake: boolean) => { /* TODO */ },

      /**
       * Only implement if label exists.
       * Floats the label above the input element if shouldFloat is true.
       * @param {boolean} shouldFloat
       */
      floatLabel: (shouldFloat: boolean) => { /* TODO */ },

      /**
       * Returns true if label element exists, false if it doesn't.
       * @return {boolean}
       */
      hasLabel: () =>
        !!this.$refs.label,

      /**
       * Only implement if label exists.
       * Returns width of label in pixels.
       * @return {number}
       */
      getLabelWidth: () => { /* TODO */ },

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
