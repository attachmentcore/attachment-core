import { f as registerInstance, g as createEvent, e as h } from './attachmentsystem-9dcd5be0.js';
import { a as AttachmentItemUploadModel } from './chunk-7b2b5b59.js';
import { a as Tunnel } from './chunk-8899376d.js';

class CreateComponent {
    constructor(hostRef) {
        registerInstance(this, hostRef);
        this.onCreate = createEvent(this, "onCreate", 7);
        this.onRequest = createEvent(this, "onRequest", 7);
    }
    renderCreate() {
        let className = "";
        if (!this.files || this.files.length == 0)
            className = "disabled";
        return h("p", { class: "control" }, h("a", { class: "button is-success is-outlined " + className, onClick: () => this.postAttachment() }, h("span", { class: "icon " }, h("attachment-icon", { "icon-name": "ok" })), h("span", null, "Create")));
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
        this.AttachmentBusiness.Upload(model).then(() => {
            this.descriptionInput.value = '';
            this.fileInput.value = '';
            this.files = null;
            this.render();
            this.onCreate.emit({});
        });
    }
    render() {
        return [
            h("div", { class: "create-form field is-grouped" }, h("p", { class: "control is-expanded" }, h("input", { class: "input", type: "file", name: "files", multiple: true, id: "file", ref: el => this.fileInput = el, onChange: ($event) => { this.files = $event.target.files; } }), h("input", { class: "input", type: "text", placeholder: "Description", ref: el => this.descriptionInput = el, value: this.description, onInput: ($event) => { this.description = $event.target.value; } })), this.renderCreate())
        ];
    }
    static get style() { return ".create-form input.input {\n  display: inline-block;\n  width: 49.5%;\n}\n.create-form input.input[type=file] {\n  margin-right: 1%;\n}\n.create-form p {\n  margin-top: 4px;\n  margin-bottom: 4px;\n}\n.create-form .button.disabled {\n  opacity: 0.7;\n  pointer-events: none;\n  cursor: not-allowed;\n}"; }
}
Tunnel.injectProps(CreateComponent, ['AttachmentKey', 'AttachmentBusiness']);

export { CreateComponent as attachment_create };
