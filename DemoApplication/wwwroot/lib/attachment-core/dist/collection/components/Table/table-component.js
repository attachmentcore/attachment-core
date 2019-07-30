import { h } from '@stencil/core';
import { GetAllAttachmentItems, Delete, Download } from '../../utils/Services';
import Tunnel from '../../utils/AttachmentKeyStateTunnel';
export class TableComponent {
    componentDidLoad() {
        this.create.addEventListener("onCreate", () => {
            this.Refresh().then((data) => {
                this.onEndLoading.emit(data);
            });
        });
        this.create.addEventListener("onRequest", () => {
            this.onStartLoading.emit({});
        });
        this.deleteComfirmation.addEventListener("onAccept", (event) => {
            this.onStartLoading.emit({});
            Delete(this.getAttachmentItemKey(event.detail.id)).then(() => {
                this.Refresh().then((data) => {
                    this.onEndLoading.emit(data);
                });
            });
        });
    }
    async Load(pageIndex, pageSize) {
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
    async Refresh() {
        return this.Load(this.pageItems.pageIndex, this.pageItems.pageSize)
            .then(data => {
            return data;
        });
    }
    getAttachmentItemKey(id) {
        return {
            attachmentId: this.AttachmentKey.attachmentId,
            entityName: this.AttachmentKey.entityName,
            fieldName: this.AttachmentKey.fieldName,
            entityId: this.AttachmentKey.entityId,
            attachmentItemId: id
        };
    }
    delete(attachmentItem) {
        this.deleteComfirmation.open(attachmentItem);
    }
    download(attachmentItem) {
        Download({
            attachmentId: this.AttachmentKey.attachmentId,
            entityName: this.AttachmentKey.entityName,
            fieldName: this.AttachmentKey.fieldName,
            entityId: this.AttachmentKey.entityId,
            attachmentItemId: attachmentItem.id
        });
    }
    info(attachmentItem) {
        this.infoDialog.open(attachmentItem);
    }
    renderDeleteButton(attachmentItem) {
        return (h("a", { class: "button is-danger is-small is-outlined ", onClick: () => this.delete(attachmentItem) },
            h("span", { class: "icon is-small" },
                h("attachment-icon", { "icon-name": "delete" }))));
    }
    renderDownloadButton(attachmentItem) {
        return (h("a", { class: "button is-primary is-small is-outlined ", onClick: () => { this.download(attachmentItem); } },
            h("span", { class: "icon is-small" },
                h("attachment-icon", { "icon-name": "download" }))));
    }
    renderInfoButton(attachmentItem) {
        return (h("a", { class: "button is-info is-small is-outlined ", onClick: () => this.info(attachmentItem) },
            h("span", { class: "icon is-small" },
                h("attachment-icon", { "icon-name": "details" }))));
    }
    renderRows() {
        if (this.pageItems)
            return this.pageItems.items.map((item, index) => {
                let id = ((this.pageItems.pageIndex - 1) * this.pageItems.pageSize) + index + 1;
                return (h("tr", null,
                    h("td", { "data-column": "Id" }, id),
                    h("td", { "data-column": "Name" }, item.fileName),
                    h("td", { "data-column": "Description" }, item.description),
                    h("td", { "data-column": "Operations" },
                        this.renderDownloadButton(item),
                        this.renderInfoButton(item),
                        this.renderDeleteButton(item))));
            });
    }
    render() {
        return [
            h("attachment-create", { "attachment-key": this.AttachmentKey, ref: el => (this.create = el) }),
            h("table", { class: "table is-bordered is-striped is-narrow is-hoverable is-fullwidth" },
                h("thead", null,
                    h("tr", null,
                        h("th", { class: "id" }, "Id"),
                        h("th", { class: "name" }, "Name"),
                        h("th", { class: "description" }, "Description"),
                        h("th", { class: "operations" }, "Operations"))),
                h("tbody", null, this.renderRows())),
            h("delete-comfirmation", { ref: el => this.deleteComfirmation = el }),
            h("info-dialog", { ref: el => this.infoDialog = el }),
        ];
    }
    static get is() { return "attachment-table"; }
    static get originalStyleUrls() { return {
        "$": ["table-component.scss"]
    }; }
    static get styleUrls() { return {
        "$": ["table-component.css"]
    }; }
    static get properties() { return {
        "AttachmentKey": {
            "type": "unknown",
            "mutable": false,
            "complexType": {
                "original": "AttachmentKeyModel",
                "resolved": "AttachmentKeyModel",
                "references": {
                    "AttachmentKeyModel": {
                        "location": "import",
                        "path": "../../utils/Models"
                    }
                }
            },
            "required": false,
            "optional": false,
            "docs": {
                "tags": [],
                "text": ""
            }
        }
    }; }
    static get states() { return {
        "pageItems": {}
    }; }
    static get events() { return [{
            "method": "onStartLoading",
            "name": "onStartLoading",
            "bubbles": true,
            "cancelable": true,
            "composed": true,
            "docs": {
                "tags": [],
                "text": ""
            },
            "complexType": {
                "original": "any",
                "resolved": "any",
                "references": {}
            }
        }, {
            "method": "onEndLoading",
            "name": "onEndLoading",
            "bubbles": true,
            "cancelable": true,
            "composed": true,
            "docs": {
                "tags": [],
                "text": ""
            },
            "complexType": {
                "original": "any",
                "resolved": "any",
                "references": {}
            }
        }]; }
    static get methods() { return {
        "Load": {
            "complexType": {
                "signature": "(pageIndex: number, pageSize: number) => Promise<AttachmentItemPagedList>",
                "parameters": [{
                        "tags": [],
                        "text": ""
                    }, {
                        "tags": [],
                        "text": ""
                    }],
                "references": {
                    "Promise": {
                        "location": "global"
                    },
                    "AttachmentItemPagedList": {
                        "location": "import",
                        "path": "../../utils/Models"
                    }
                },
                "return": "Promise<AttachmentItemPagedList>"
            },
            "docs": {
                "text": "",
                "tags": []
            }
        },
        "Refresh": {
            "complexType": {
                "signature": "() => Promise<AttachmentItemPagedList>",
                "parameters": [],
                "references": {
                    "Promise": {
                        "location": "global"
                    },
                    "AttachmentItemPagedList": {
                        "location": "import",
                        "path": "../../utils/Models"
                    }
                },
                "return": "Promise<AttachmentItemPagedList>"
            },
            "docs": {
                "text": "",
                "tags": []
            }
        }
    }; }
}
Tunnel.injectProps(TableComponent, ['AttachmentKey']);
