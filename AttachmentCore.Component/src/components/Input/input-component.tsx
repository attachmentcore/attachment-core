import { Component, Element, h, State, Prop } from '@stencil/core';
import { AttachmentBusiness } from '../../utils/Services';
import { AttachmentModel, AttachmentKeyModel } from '../../utils/Models';
import Tunnel from '../../utils/AttachmentStateTunnel';

@Component({
  tag: 'attachment-input',
  styleUrl: 'input-component.scss',
  shadow: true
})
export class AttachmentInputComponent {
  modal: HTMLAttachmentModalElement;
  @Element() host: HTMLDivElement;

  attachmentBusiness: AttachmentBusiness;

  @Prop() EntityName: string;
  @Prop() FieldName: string;
  @Prop() EntityId: string;
  @Prop() Placeholder: string;
  @Prop() BaseUrl: string;
  @State() Attachment: AttachmentModel;
  @State() loading: boolean = false;
  @State() error: boolean = false;

  openModal() {
    this.modal.open();
  }
  getAttachmentId() {
    if (!this.EntityName || !this.FieldName) {
      this.error = true;
      return;
    }
    this.loading = true;

    this.attachmentBusiness.GetAttachmentId(this.EntityName, this.FieldName, this.EntityId).then(response => {
      this.Attachment = response;
      this.error = false;
      this.loading = false;
    }).catch(() => {
      this.loading = false;
      this.error = true;
      throw new Error("Error in get attachment id from the server");
    });
  }
  renderIcon() {
    if (this.error)
      return (
        <div class="control ">
          <a class="button is-danger" onClick={() => { this.getAttachmentId() }}>
            <span class="icon is-small">
              <attachment-icon icon-name="retry"></attachment-icon>
            </span>
          </a>
        </div>
      );
    if (!this.loading)
      return (
        <div class="control ">
          <a class="button is-info" onClick={() => { this.openModal() }}>
            <span class="icon is-small">
              <attachment-icon icon-name="attachment"></attachment-icon>
            </span>
          </a>
        </div>
      );
  }
  renderModal() {
    if (this.Attachment && this.Attachment.attachmentId) {
      const attachmentKey = new AttachmentKeyModel();
      attachmentKey.attachmentId = this.Attachment.attachmentId;
      attachmentKey.entityName = this.EntityName;
      attachmentKey.fieldName = this.FieldName;
      attachmentKey.entityId = this.EntityId;

      return (
        <Tunnel.Provider state={{ AttachmentKey: attachmentKey, AttachmentBusiness: this.attachmentBusiness }} >
          <attachment-modal ref={el => (this.modal = el)} ></attachment-modal>
        </Tunnel.Provider>
      )
    }
  }

  componentDidLoad() {
    this.attachmentBusiness = new AttachmentBusiness(this.BaseUrl);
    this.getAttachmentId();
  }

  render() {
    return [
      <div class="field has-addons attachment-core-input" >
        <div class={"control " + (this.loading ? "is-loading" : "")}>
          <input class="input" type="text" placeholder={this.Placeholder ? this.Placeholder : ""} />
        </div>
        {this.renderIcon()}
      </div>,
      this.renderModal()
    ];
  }
}
