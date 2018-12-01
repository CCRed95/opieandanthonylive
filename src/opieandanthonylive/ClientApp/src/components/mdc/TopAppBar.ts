import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { MDCTopAppBar } from '@material/top-app-bar';

@Component
export default class TopAppBarFixed extends Vue {

  @Prop(String) public title!: string;

  private adapter: any;

  public mounted() {
    this.adapter = new MDCTopAppBar(this.$el);
    this.adapter.initialize();
  }

  public beforeDestroy() {
    if (this.adapter != null) {
      this.adapter.destroy();
      this.adapter = null;
    }
  }

}
