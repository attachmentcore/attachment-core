import { Component, h, Method, Element, Prop, State } from '@stencil/core';
import { AttachmentItemPagedList, AttachmentKeyModel } from '../../utils/Models';
import Tunnel from '../../utils/AttachmentStateTunnel';

@Component({
  tag: 'attachment-modal',
  styleUrl: 'modal-component.scss',
  shadow: false
})
export class ModalComponent {
  @Element() el: HTMLElement;
  wrapper: HTMLDivElement;
  table: HTMLAttachmentTableElement;
  popup: HTMLAttachmentPopupElement;

  componentDidLoad() {
    this.table.addEventListener("onStartLoading", () => {
      this.loading = true;
    });
    this.table.addEventListener("onEndLoading", (data: any) => {
      this.pageItems = data.detail as AttachmentItemPagedList;
      this.loading = false;
    });
  }

  @Prop() AttachmentKey: AttachmentKeyModel;
  @State() loading: boolean;
  @State() opened: boolean;
  @State() pageItems: AttachmentItemPagedList;
  @Method()
  async open() {
    this.load(1, 5);
    this.popup.open();
  }
  @Method()
  async close() {
    this.popup.close();
  }

  load(index: number, pageSize: number) {
    this.table.Load(index, pageSize).then((pageItems) => {
      this.pageItems = pageItems;
    });
  }

  renderReloader() {
    return <a class={"button is-info spinner " + (this.loading ? "is-loading" : "")} onClick={() =>
      this.load(this.pageItems.pageIndex, this.pageItems.pageSize)}>
      <span class="icon is-small">
        {!this.loading ? [<attachment-icon icon-name="reload"></attachment-icon>] : []}
      </span>
    </a>;
  }
  renderPager() {
    if (!this.pageItems)
      return;
    let first = 1;
    let last = Math.ceil(this.pageItems.totalItemsCount / this.pageItems.pageSize);
    let prev = this.pageItems.pageIndex - 1;
    let next = this.pageItems.pageIndex + 1;
    if (first != last)
      return (
        <nav class="pagination is-centered" role="navigation" aria-label="pagination">
          <ul class="pagination-list">
            {first < this.pageItems.pageIndex ? [<li><a class="pagination-link" aria-label="Goto page 1" onClick={() => { this.load(first, this.pageItems.pageSize) }}>{first}</a></li>] : []}
            {first + 1 < prev ? [<li><span class="pagination-ellipsis">&hellip;</span></li>] : []}
            {first < prev ? [<li><a class="pagination-link" aria-label="Goto page 45" onClick={() => { this.load(prev, this.pageItems.pageSize) }} >{prev}</a></li>] : []}
            {this.pageItems.totalItemsCount != 0 ? <li><a class="pagination-link is-current" aria-label="Page 46" aria-current="page">{this.pageItems.pageIndex}</a></li> : []}
            {last > next ? [<li><a class="pagination-link" aria-label="Goto page 47" onClick={() => { this.load(next, this.pageItems.pageSize) }}>{next}</a></li>] : []}
            {last - 1 > next ? [<li><span class="pagination-ellipsis">&hellip;</span></li>] : []}
            {last > this.pageItems.pageIndex ? [< li > <a class="pagination-link" aria-label="Goto page 86" onClick={() => { this.load(last, this.pageItems.pageSize) }}>{last}</a></li>] : []}
          </ul>
        </nav>
      );
  }

  render() {
    let classNames: string = "";
    if (this.loading)
      classNames += " loading";

    return [
      <attachment-popup class={classNames} ref={el => (this.popup = el)} >
        <div class="modal-card">
          <header class="modal-card-head">
            <label class="modal-card-title">Attachments List</label>
          </header>
          <section class={"modal-card-body " + (this.loading ? "disabled" : "")}>
            <attachment-table ref={el => (this.table = el)}></attachment-table>
          </section>
          <footer class="modal-card-foot">
            {this.renderPager()}
            {this.renderReloader()}
          </footer>
          <button class="modal-close is-large" onClick={() => this.popup.close()} aria-label="close"></button>
        </div>
      </attachment-popup>
    ];
  }
}
Tunnel.injectProps(ModalComponent, ['AttachmentKey']);
