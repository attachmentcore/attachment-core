import { f as registerInstance, e as h } from './attachmentsystem-9dcd5be0.js';
import { c as FormatSize, d as FormatDate } from './chunk-edcd45f1.js';

class InfoDialogComponent {
    constructor(hostRef) {
        registerInstance(this, hostRef);
    }
    async open(attachmentItem) {
        this.attachmentItem = attachmentItem;
        this.popup.open();
    }
    async close() {
        this.popup.close();
    }
    renderClose() {
        return (h("a", { class: "button is-danger is-outlined", onClick: () => { this.close(); } }, h("span", { class: "icon is-small" }, h("attachment-icon", { "icon-name": "delete" })), h("span", null, "CLose")));
    }
    renderInfo() {
        if (this.attachmentItem)
            return (h("ul", null, h("li", null, h("b", null, "Name"), " ", this.attachmentItem.fileName), h("li", null, h("b", null, "Description"), " ", this.attachmentItem.description), h("li", null, h("b", null, "Size"), " ", FormatSize(this.attachmentItem.fileSize)), h("li", null, h("b", null, "UploadDate"), " ", FormatDate(this.attachmentItem.uploadDate))));
    }
    render() {
        return [
            h("attachment-popup", { ref: el => (this.popup = el) }, h("div", { class: "modal-card" }, h("header", { class: "modal-card-head" }, h("label", { class: "modal-card-title" }, "Attachment Item Details")), h("section", { class: "modal-card-body" }, this.renderInfo()), h("footer", { class: "modal-card-foot" }, this.renderClose())))
        ];
    }
    static get style() { return "info-dialog > attachment-popup > .modal > .modal-card > .modal-card-head {\n  padding: 5px;\n}\ninfo-dialog > attachment-popup > .modal > .modal-card > .modal-card-head .modal-card-title {\n  padding-left: 15px;\n  padding-bottom: 10px;\n  padding-top: 10px;\n  font-size: 18px !important;\n  font-weight: bold;\n}\ninfo-dialog ul {\n  columns: 2;\n  -webkit-columns: 2;\n  -moz-columns: 2;\n  list-style-type: none;\n}\ninfo-dialog ul b {\n  display: block;\n  margin-right: 0.5em;\n}\ninfo-dialog ul li {\n  word-break: break-all;\n}"; }
}

export { InfoDialogComponent as info_dialog };
