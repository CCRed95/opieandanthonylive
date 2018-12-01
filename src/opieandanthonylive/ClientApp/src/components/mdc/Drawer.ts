import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { MDCModalDrawerFoundation, util } from '@material/drawer';
import { FocusTrap } from 'focus-trap';

@Component
export default class ModalDrawer extends Vue {

  public classes: any = {};

  private foundation: any;
  private previousFocus: any;
  private focusTrap?: FocusTrap;

  public mounted() {
    this.focusTrap = util.createFocusTrapInstance(this.drawer);
    this.foundation = new MDCModalDrawerFoundation(this.adapter);
    this.foundation.init();
  }

  public beforeDestroy() {
    if (this.foundation != null) {
      this.foundation.destroy();
    }
  }

  public open() {
    if (this.foundation !== null) {
      this.foundation.open();
    }
  }

  public close() {
    if (this.foundation !== null) {
      /*
       * HACK: For some reason I don't understand, sometimes opening the drawer
       * doesn't trigger a transition.  Consequently, the `transitionend`
       * handler is never run the and drawer gets stuck.
       *
       * This hack relies on implementation details of the handler, forcibly
       * removing transition class which prevents it from closing the drawer.
       */
      this.$delete(this.classes, 'mdc-drawer--opening');
      this.foundation.close();
    }
  }

  public transitionEnd(e: Event) {
    this.foundation.handleTransitionEnd(e);
  }

  private get drawer() {
    return this.$refs.drawer;
  }

  private get adapter() {
    const self = this;

    return {

      trapFocus: () => {
        if (self.focusTrap) {
          self.focusTrap.activate();
        }
      },

      releaseFocus: () => {
        if (self.focusTrap) {
          self.focusTrap.deactivate();
        }
      },

      addClass:    (className: string) =>  self.$set(self.classes, className, true),
      removeClass: (className: string) =>  self.$delete(self.classes, className),
      hasClass:    (className: string): boolean => className in self.classes,

      elementHasClass: (element: Element, className: string): boolean =>
        element.classList.contains(className),

      saveFocus: () => self.previousFocus = document.activeElement,

      restoreFocus: () => {
        if (self.previousFocus instanceof HTMLElement &&
            self.drawer instanceof Element &&
            self.drawer.contains(document.activeElement)) {
          self.previousFocus.focus();
        }
      },

      focusActiveNavigationItem: () => {
        if (self.drawer instanceof Element) {
          const activeElement = self.drawer.querySelector('.mdc-list-item--activated');
          if (activeElement instanceof HTMLElement) {
            activeElement.focus();
          }
        }
      },

      notifyOpen: () => { /* */ },
      notifyClose: () => { /* */ },

    };
  }

}
