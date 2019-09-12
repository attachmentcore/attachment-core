import { Component, h, Method, State, Event, EventEmitter } from '@stencil/core';
import { AttachmentItem } from '../../utils/Models';
import { FormatDate, FormatSize } from '../../utils/utils';

@Component({
  tag: 'delete-comfirmation',
  styleUrl: 'delete-comfirmation-component.scss',
  shadow: false
})
export class DeleteComfirmationComponent {
  popup: HTMLAttachmentPopupElement;
  

  @Event() onAccept: EventEmitter;
  @Event() onCancel: EventEmitter;
  @State() attachmentItem: AttachmentItem;
  @Method()
  async open(attachmentItem: AttachmentItem) {
    this.attachmentItem = attachmentItem;
    this.popup.open();
  }
  @Method()
  async close() {
    this.popup.close();
  }

  accept(attachmentItem: AttachmentItem) {
    this.onAccept.emit(attachmentItem);
    this.close();
  }
  cancel(attachmentItem: AttachmentItem) {
    this.onCancel.emit(attachmentItem);
    this.close();
  }

  renderAccept() {
    return (
      <a class="button is-primary is-outlined" onClick={() => { this.accept(this.attachmentItem) }}>
        <span class="icon is-small">
          <attachment-icon icon-name="ok"></attachment-icon>
        </span>
        <span>OK</span>
      </a>
    );
  }
  renderCancel() {
    return (
      <a class="button is-danger is-outlined" onClick={() => { this.cancel(this.attachmentItem) }}>
        <span class="icon is-small">
          <attachment-icon icon-name="delete"></attachment-icon>
        </span>
        <span>Cancel</span>
      </a>
    );
  }
  renderInfo() {
    if (this.attachmentItem)
      return (
        <ul>
          <li><b>Name </b> {this.attachmentItem.fileName}</li>
          <li><b>Description </b> {this.attachmentItem.description}</li>
          <li><b>Size </b> {FormatSize(this.attachmentItem.fileSize)}</li>
          <li><b>UploadDate </b> { FormatDate(this.attachmentItem.uploadDate) }</li>
        </ul>
      );
  }

  render() {
    return [
      <attachment-popup ref={el => this.popup = el} >
        <div class="modal-card">
          <header class="modal-card-head">
            <label class="modal-card-title">Delete Confirmation</label>
          </header>
          <section class="modal-card-body">
            <h1>Are you sure to delete this file attachment?</h1>
            {this.renderInfo()}
          </section>
          <footer class="modal-card-foot">
            {this.renderAccept()}
            {this.renderCancel()}
          </footer>
        </div>
      </attachment-popup>
    ];
  }
}
