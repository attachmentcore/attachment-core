import { h } from '@stencil/core';
import { FormatDate, FormatSize } from '../../utils/utils';
export class InfoDialogComponent {
    async open(attachmentItem) {
        this.attachmentItem = attachmentItem;
        this.popup.open();
    }
    async close() {
        this.popup.close();
    }
    renderClose() {
        return (h("a", { class: "button is-danger is-outlined", onClick: () => { this.close(); } },
            h("span", { class: "icon is-small" },
                h("attachment-icon", { "icon-name": "delete" })),
            h("span", null, "CLose")));
    }
    renderInfo() {
        if (this.attachmentItem)
            return (h("ul", null,
                h("li", null,
                    h("b", null, "Name"),
                    " ",
                    this.attachmentItem.fileName),
                h("li", null,
                    h("b", null, "Description"),
                    " ",
                    this.attachmentItem.description),
                h("li", null,
                    h("b", null, "Size"),
                    " ",
                    FormatSize(this.attachmentItem.fileSize)),
                h("li", null,
                    h("b", null, "UploadDate"),
                    " ",
                    FormatDate(this.attachmentItem.uploadDate))));
    }
    render() {
        return [
            h("attachment-popup", { ref: el => (this.popup = el) },
                h("div", { class: "modal-card" },
                    h("header", { class: "modal-card-head" },
                        h("label", { class: "modal-card-title" }, "Attachment Item Details")),
                    h("section", { class: "modal-card-body" }, this.renderInfo()),
                    h("footer", { class: "modal-card-foot" }, this.renderClose())))
        ];
    }
    static get is() { return "info-dialog"; }
    static get originalStyleUrls() { return {
        "$": ["info-dialog-component.scss"]
    }; }
    static get styleUrls() { return {
        "$": ["info-dialog-component.css"]
    }; }
    static get states() { return {
        "attachmentItem": {}
    }; }
    static get methods() { return {
        "open": {
            "complexType": {
                "signature": "(attachmentItem: AttachmentItem) => Promise<void>",
                "parameters": [{
                        "tags": [],
                        "text": ""
                    }],
                "references": {
                    "Promise": {
                        "location": "global"
                    },
                    "AttachmentItem": {
                        "location": "import",
                        "path": "../../utils/Models"
                    }
                },
                "return": "Promise<void>"
            },
            "docs": {
                "text": "",
                "tags": []
            }
        },
        "close": {
            "complexType": {
                "signature": "() => Promise<void>",
                "parameters": [],
                "references": {
                    "Promise": {
                        "location": "global"
                    }
                },
                "return": "Promise<void>"
            },
            "docs": {
                "text": "",
                "tags": []
            }
        }
    }; }
}
