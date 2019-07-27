import { Component, h, Prop, Event, EventEmitter, State } from '@stencil/core';
import { Upload } from '../../utils/Services';
import { AttachmentItemUploadModel, AttachmentKeyModel } from '../../utils/Models';
import Tunnel from '../../utils/AttachmentKeyStateTunnel';

@Component({
  tag: 'attachment-create',
  styleUrl: 'create-component.scss',
  shadow: false
})
export class CreateComponent {
  fileInput: HTMLInputElement;
  descriptionInput: HTMLInputElement;

  @Prop() AttachmentKey: AttachmentKeyModel;
  @Event() onCreate: EventEmitter;
  @Event() onRequest: EventEmitter;
  @State() files: FileList;
  @State() description: string;

  renderCreate() {
    let className = "";
    if (!this.files || this.files.length == 0)
      className = "disabled";
    
    return <p class="control">
      <a class={"button is-success is-outlined " + className} onClick={() => this.postAttachment()}>
        <span class="icon ">
          <attachment-icon icon-name="ok"></attachment-icon>
        </span>
        <span>Create</span>
      </a>
    </p>
  }
  
  postAttachment() {
    if (this.files.length == 0)
      throw Error("File content must have value");

    if (!this.AttachmentKey)
      throw Error("AttachmentId don't have value");

    let model = new AttachmentItemUploadModel();
    model.attachmentId = this.AttachmentKey.attachmentId;
    model.entityName = this.AttachmentKey.entityName;
    model.fieldName = this.AttachmentKey.fieldName;
    model.entityId = this.AttachmentKey.entityId;
    model.description = this.description;
    model.fileContent = this.files;
    this.onRequest.emit({});

    Upload(model).then(() => {
      this.descriptionInput.value = '';
      this.fileInput.value = '';
      this.files = null;
      this.render()
      this.onCreate.emit({});
    });
  }

  render() {
    return [
      <div class="create-form field is-grouped">
        <p class="control is-expanded">
          <input class="input" type="file" name="files" multiple id="file" ref={el => this.fileInput = el} onChange={($event: any) => { this.files = $event.target.files; }} />
          <input class="input" type="text" placeholder="Description" ref={el => this.descriptionInput = el} value={this.description} onInput={($event: any) => this.description = $event.target.value} />
        </p>
        { this.renderCreate() }
      </div>
    ];
  }
}
Tunnel.injectProps(CreateComponent, ['AttachmentKey']);
