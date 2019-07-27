import { Component, Method, State, h, Prop, Event, EventEmitter } from '@stencil/core';
import { GetAllAttachmentItems, Delete, Download } from '../../utils/Services';
import { AttachmentItemPagedList, AttachmentKeyModel, AttachmentItemKeyModel, AttachmentItem } from '../../utils/Models';
import Tunnel from '../../utils/AttachmentKeyStateTunnel';

@Component({
  tag: 'attachment-table',
  styleUrl: 'table-component.scss',
  shadow: false
})
export class TableComponent {
  deleteComfirmation: HTMLDeleteComfirmationElement;
  infoDialog: HTMLInfoDialogElement;
  create: HTMLAttachmentCreateElement;

  componentDidLoad() {
    this.create.addEventListener("onCreate", () => {
      this.Refresh().then((data) => {
        this.onEndLoading.emit(data);
        });
      });
    this.create.addEventListener("onRequest", () => {
      this.onStartLoading.emit({});

    });
    this.deleteComfirmation.addEventListener("onAccept", (event:any) => {
      this.onStartLoading.emit({});

        Delete(this.getAttachmentItemKey(event.detail.id)).then(() => {
          this.Refresh().then((data) => {
            this.onEndLoading.emit(data);
          });
        });
      });
  }
  @Event() onStartLoading: EventEmitter;
  @Event() onEndLoading: EventEmitter;
  @State() pageItems: AttachmentItemPagedList;
  @Prop() AttachmentKey: AttachmentKeyModel;
  @Method()
  async Load(pageIndex: number, pageSize: number): Promise<AttachmentItemPagedList> {
    console.log(pageIndex, pageSize);
    if (pageIndex < 1)
      return;
    this.onStartLoading.emit({});

    return GetAllAttachmentItems({
      attachmentId: this.AttachmentKey.attachmentId,
      entityName: this.AttachmentKey.entityName,
      fieldName: this.AttachmentKey.fieldName,
      entityId: this.AttachmentKey.entityId,
      pageIndex: pageIndex,
      pageSize: pageSize
    }).then(data => {
      this.pageItems = data;
      this.onEndLoading.emit(data);
      return data;
    });
  }
  @Method()
  async Refresh(): Promise<AttachmentItemPagedList> {
    return this.Load(this.pageItems.pageIndex, this.pageItems.pageSize)
      .then(data => {
      return data;
    });
  }

  getAttachmentItemKey(id: number): AttachmentItemKeyModel {
    return  {
      attachmentId: this.AttachmentKey.attachmentId,
      entityName: this.AttachmentKey.entityName,
      fieldName: this.AttachmentKey.fieldName,
      entityId: this.AttachmentKey.entityId,
      attachmentItemId: id
    }
  }
  delete(attachmentItem: AttachmentItem) {
    this.deleteComfirmation.open(attachmentItem);
  }
  download(attachmentItem: AttachmentItem) {
    Download({
      attachmentId: this.AttachmentKey.attachmentId,
      entityName: this.AttachmentKey.entityName,
      fieldName: this.AttachmentKey.fieldName,
      entityId: this.AttachmentKey.entityId,
      attachmentItemId: attachmentItem.id
    });
  }
  info(attachmentItem: AttachmentItem) {
    this.infoDialog.open(attachmentItem);
  }

  renderDeleteButton(attachmentItem: AttachmentItem) {
    return (
      <a class="button is-danger is-small is-outlined " onClick={() => this.delete(attachmentItem)}>
        <span class="icon is-small">
          <attachment-icon icon-name="delete"></attachment-icon>
        </span>
      </a>
    );
  }
  renderDownloadButton(attachmentItem: AttachmentItem) {
    return (
      <a class="button is-primary is-small is-outlined " onClick={() => { this.download(attachmentItem) }}>
        <span class="icon is-small">
          <attachment-icon icon-name="download"></attachment-icon>
        </span>
      </a>
    );
  }
  renderInfoButton(attachmentItem: AttachmentItem) {
    return (
      <a class="button is-info is-small is-outlined " onClick={() => this.info(attachmentItem)}>
        <span class="icon is-small">
          <attachment-icon icon-name="details"></attachment-icon>
        </span>
      </a>
    );
  }
  renderRows() {
    if (this.pageItems)
      return this.pageItems.items.map((item, index) => {
        let id = ((this.pageItems.pageIndex - 1) * this.pageItems.pageSize) + index + 1;
        return (
          <tr>
            <td data-column="Id">{id}</td>
            <td data-column="Name">{item.fileName}</td>
            <td data-column="Description">{item.description}</td>
            <td data-column="Operations">
              {this.renderDownloadButton(item)}
              {this.renderInfoButton(item)}
              {this.renderDeleteButton(item)}
            </td>
          </tr> );
      });
  }

  render() {
    return [
      <attachment-create attachment-key={this.AttachmentKey} ref={el => (this.create = el)}></attachment-create>
      ,
      <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
        <thead>
          <tr>
            <th class="id">Id</th>
            <th class="name">Name</th>
            <th class="description">Description</th>
            <th class="operations">Operations</th>
          </tr>
        </thead>
        <tbody>
          {
            this.renderRows()
          }
        </tbody>
      </table>,
      <delete-comfirmation ref={el => this.deleteComfirmation = el} ></delete-comfirmation>,
      <info-dialog ref={el => this.infoDialog = el} ></info-dialog>,
    ];
  }
}
Tunnel.injectProps(TableComponent, ['AttachmentKey']);

