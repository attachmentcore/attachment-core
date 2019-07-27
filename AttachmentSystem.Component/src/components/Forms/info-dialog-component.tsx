import { Component, h, Method, State } from '@stencil/core';
import { AttachmentItem } from '../../utils/Models';
import { FormatDate, FormatSize } from '../../utils/utils';

@Component({
  tag: 'info-dialog',
  styleUrl: 'info-dialog-component.scss',
  shadow: false
})
export class InfoDialogComponent {
  wrapper: HTMLDivElement;
  popup: HTMLAttachmentPopupElement;

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

  renderClose() {
    return (
      <a class="button is-danger is-outlined" onClick={() => { this.close() }}>
        <span class="icon is-small">
          <attachment-icon icon-name="delete"></attachment-icon>
        </span>
        <span>CLose</span>
      </a>
    );
  }
  renderInfo() {
    if (this.attachmentItem)
      return (
        <ul>
          <li><b>Name</b> {this.attachmentItem.fileName}</li>
          <li><b>Description</b> {this.attachmentItem.description}</li>
          <li><b>Size</b> {FormatSize(this.attachmentItem.fileSize)}</li>
          <li><b>UploadDate</b> { FormatDate(this.attachmentItem.uploadDate) }</li>
        </ul>
      );
  }

  render() {
    return [
      <attachment-popup ref={el => (this.popup = el)} >
        <div class="modal-card">
          <header class="modal-card-head">
            <label class="modal-card-title">Attachment Item Details</label>
          </header>
          <section class="modal-card-body">
            {this.renderInfo()}
          </section>
          <footer class="modal-card-foot">
            {this.renderClose()}
          </footer>
        </div>
      </attachment-popup>
    ];
  }
}
