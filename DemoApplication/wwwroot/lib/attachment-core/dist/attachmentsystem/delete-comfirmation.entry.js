import { f as registerInstance, g as createEvent, e as h } from './attachmentsystem-9dcd5be0.js';
import { c as FormatSize, d as FormatDate } from './chunk-edcd45f1.js';

class DeleteComfirmationComponent {
    constructor(hostRef) {
        registerInstance(this, hostRef);
        this.onAccept = createEvent(this, "onAccept", 7);
        this.onCancel = createEvent(this, "onCancel", 7);
    }
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
        return (h("a", { class: "button is-primary is-outlined", onClick: () => { this.accept(this.attachmentItem); } }, h("span", { class: "icon is-small" }, h("attachment-icon", { "icon-name": "ok" })), h("span", null, "OK")));
    }
    renderCancel() {
        return (h("a", { class: "button is-danger is-outlined", onClick: () => { this.cancel(this.attachmentItem); } }, h("span", { class: "icon is-small" }, h("attachment-icon", { "icon-name": "delete" })), h("span", null, "Cancel")));
    }
    renderInfo() {
        if (this.attachmentItem)
            return (h("ul", null, h("li", null, h("b", null, "Name "), " ", this.attachmentItem.fileName), h("li", null, h("b", null, "Description "), " ", this.attachmentItem.description), h("li", null, h("b", null, "Size "), " ", FormatSize(this.attachmentItem.fileSize)), h("li", null, h("b", null, "UploadDate "), " ", FormatDate(this.attachmentItem.uploadDate))));
    }
    render() {
        return [
            h("attachment-popup", { ref: el => this.popup = el }, h("div", { class: "modal-card" }, h("header", { class: "modal-card-head" }, h("label", { class: "modal-card-title" }, "Delete Confirmation")), h("section", { class: "modal-card-body" }, h("h1", null, "Are you sure to delete this file attachment?"), this.renderInfo()), h("footer", { class: "modal-card-foot" }, this.renderAccept(), this.renderCancel())))
        ];
    }
    static get style() { return "delete-comfirmation > attachment-popup > .modal > .modal-card > .modal-card-head {\n  padding: 5px;\n}\ndelete-comfirmation > attachment-popup > .modal > .modal-card > .modal-card-head .modal-card-title {\n  padding-left: 15px;\n  padding-bottom: 10px;\n  padding-top: 10px;\n  font-size: 18px !important;\n  font-weight: bold;\n}\ndelete-comfirmation ul {\n  columns: 2;\n  -webkit-columns: 2;\n  -moz-columns: 2;\n  list-style-type: none;\n}\ndelete-comfirmation ul b {\n  display: block;\n  margin-right: 0.5em;\n}\ndelete-comfirmation ul li {\n  word-break: break-all;\n}"; }
}

export { DeleteComfirmationComponent as delete_comfirmation };
