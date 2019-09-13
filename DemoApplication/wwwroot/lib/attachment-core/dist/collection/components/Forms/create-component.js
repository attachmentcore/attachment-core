import { h } from '@stencil/core';
import { AttachmentItemUploadModel } from '../../utils/Models';
import Tunnel from '../../utils/AttachmentStateTunnel';
export class CreateComponent {
    renderCreate() {
        let className = "";
        if (!this.files || this.files.length == 0)
            className = "disabled";
        return h("p", { class: "control" },
            h("a", { class: "button is-success is-outlined " + className, onClick: () => this.postAttachment() },
                h("span", { class: "icon " },
                    h("attachment-icon", { "icon-name": "ok" })),
                h("span", null, "Create")));
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
            h("div", { class: "create-form field is-grouped" },
                h("p", { class: "control is-expanded" },
                    h("input", { class: "input", type: "file", name: "files", multiple: true, id: "file", ref: el => this.fileInput = el, onChange: ($event) => { this.files = $event.target.files; } }),
                    h("input", { class: "input", type: "text", placeholder: "Description", ref: el => this.descriptionInput = el, value: this.description, onInput: ($event) => this.description = $event.target.value })),
                this.renderCreate())
        ];
    }
    static get is() { return "attachment-create"; }
    static get originalStyleUrls() { return {
        "$": ["create-component.scss"]
    }; }
    static get styleUrls() { return {
        "$": ["create-component.css"]
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
        },
        "AttachmentBusiness": {
            "type": "unknown",
            "mutable": false,
            "complexType": {
                "original": "AttachmentBusiness",
                "resolved": "AttachmentBusiness",
                "references": {
                    "AttachmentBusiness": {
                        "location": "import",
                        "path": "../../utils/Services"
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
        "files": {},
        "description": {}
    }; }
    static get events() { return [{
            "method": "onCreate",
            "name": "onCreate",
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
            "method": "onRequest",
            "name": "onRequest",
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
}
Tunnel.injectProps(CreateComponent, ['AttachmentKey', 'AttachmentBusiness']);
