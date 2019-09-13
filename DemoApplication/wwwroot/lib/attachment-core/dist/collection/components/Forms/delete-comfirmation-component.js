import { h } from '@stencil/core';
import { FormatDate, FormatSize } from '../../utils/utils';
export class DeleteComfirmationComponent {
    async open(attachmentItem) {
        this.attachmentItem = attachmentItem;
        this.popup.open();
    }
    async close() {
        this.popup.close();
    }
    accept(attachmentItem) {
        this.onAccept.emit(attachmentItem);
        this.close();
    }
    cancel(attachmentItem) {
        this.onCancel.emit(attachmentItem);
        this.close();
    }
    renderAccept() {
        return (h("a", { class: "button is-primary is-outlined", onClick: () => { this.accept(this.attachmentItem); } },
            h("span", { class: "icon is-small" },
                h("attachment-icon", { "icon-name": "ok" })),
            h("span", null, "OK")));
    }
    renderCancel() {
        return (h("a", { class: "button is-danger is-outlined", onClick: () => { this.cancel(this.attachmentItem); } },
            h("span", { class: "icon is-small" },
                h("attachment-icon", { "icon-name": "delete" })),
            h("span", null, "Cancel")));
    }
    renderInfo() {
        if (this.attachmentItem)
            return (h("ul", null,
                h("li", null,
                    h("b", null, "Name "),
                    " ",
                    this.attachmentItem.fileName),
                h("li", null,
                    h("b", null, "Description "),
                    " ",
                    this.attachmentItem.description),
                h("li", null,
                    h("b", null, "Size "),
                    " ",
                    FormatSize(this.attachmentItem.fileSize)),
                h("li", null,
                    h("b", null, "UploadDate "),
                    " ",
                    FormatDate(this.attachmentItem.uploadDate))));
    }
    render() {
        return [
            h("attachment-popup", { ref: el => this.popup = el },
                h("div", { class: "modal-card" },
                    h("header", { class: "modal-card-head" },
                        h("label", { class: "modal-card-title" }, "Delete Confirmation")),
                    h("section", { class: "modal-card-body" },
                        h("h1", null, "Are you sure to delete this file attachment?"),
                        this.renderInfo()),
                    h("footer", { class: "modal-card-foot" },
                        this.renderAccept(),
                        this.renderCancel())))
        ];
    }
    static get is() { return "delete-comfirmation"; }
    static get originalStyleUrls() { return {
        "$": ["delete-comfirmation-component.scss"]
    }; }
    static get styleUrls() { return {
        "$": ["delete-comfirmation-component.css"]
    }; }
    static get states() { return {
        "attachmentItem": {}
    }; }
    static get events() { return [{
            "method": "onAccept",
            "name": "onAccept",
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
            "method": "onCancel",
            "name": "onCancel",
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
