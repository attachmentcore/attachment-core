import { h } from '@stencil/core';
import { GetAttachmentId } from '../../utils/Services';
import { AttachmentKeyModel } from '../../utils/Models';
import Tunnel from '../../utils/AttachmentKeyStateTunnel';
export class AttachmentInputComponent {
    constructor() {
        this.loading = false;
        this.error = false;
    }
    openModal() {
        this.modal.open();
    }
    getAttachmentId() {
        if (!this.EntityName || !this.FieldName) {
            this.error = true;
            return;
        }
        this.loading = true;
        GetAttachmentId(this.EntityName, this.FieldName, this.EntityId).then(response => {
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
            return (h("div", { class: "control " },
                h("a", { class: "button is-danger", onClick: () => { this.getAttachmentId(); } },
                    h("span", { class: "icon is-small" },
                        h("attachment-icon", { "icon-name": "retry" })))));
        if (!this.loading)
            return (h("div", { class: "control " },
                h("a", { class: "button is-info", onClick: () => { this.openModal(); } },
                    h("span", { class: "icon is-small" },
                        h("attachment-icon", { "icon-name": "attachment" })))));
    }
    renderModal() {
        if (this.Attachment && this.Attachment.attachmentId) {
            const attachmentKey = new AttachmentKeyModel();
            attachmentKey.attachmentId = this.Attachment.attachmentId;
            attachmentKey.entityName = this.EntityName;
            attachmentKey.fieldName = this.FieldName;
            attachmentKey.entityId = this.EntityId;
            return (h(Tunnel.Provider, { state: { AttachmentKey: attachmentKey } },
                h("attachment-modal", { ref: el => (this.modal = el) })));
        }
    }
    componentDidLoad() {
        this.getAttachmentId();
    }
    render() {
        return [
            h("div", { class: "field has-addons attachment-core-input" },
                h("div", { class: "control " + (this.loading ? "is-loading" : "") },
                    h("input", { class: "input", type: "text", placeholder: this.Placeholder ? this.Placeholder : "" })),
                this.renderIcon()),
            this.renderModal()
        ];
    }
    static get is() { return "attachment-input"; }
    static get encapsulation() { return "shadow"; }
    static get originalStyleUrls() { return {
        "$": ["input-component.scss"]
    }; }
    static get styleUrls() { return {
        "$": ["input-component.css"]
    }; }
    static get properties() { return {
        "EntityName": {
            "type": "string",
            "mutable": false,
            "complexType": {
                "original": "string",
                "resolved": "string",
                "references": {}
            },
            "required": false,
            "optional": false,
            "docs": {
                "tags": [],
                "text": ""
            },
            "attribute": "entity-name",
            "reflect": false
        },
        "FieldName": {
            "type": "string",
            "mutable": false,
            "complexType": {
                "original": "string",
                "resolved": "string",
                "references": {}
            },
            "required": false,
            "optional": false,
            "docs": {
                "tags": [],
                "text": ""
            },
            "attribute": "field-name",
            "reflect": false
        },
        "EntityId": {
            "type": "string",
            "mutable": false,
            "complexType": {
                "original": "string",
                "resolved": "string",
                "references": {}
            },
            "required": false,
            "optional": false,
            "docs": {
                "tags": [],
                "text": ""
            },
            "attribute": "entity-id",
            "reflect": false
        },
        "Placeholder": {
            "type": "string",
            "mutable": false,
            "complexType": {
                "original": "string",
                "resolved": "string",
                "references": {}
            },
            "required": false,
            "optional": false,
            "docs": {
                "tags": [],
                "text": ""
            },
            "attribute": "placeholder",
            "reflect": false
        }
    }; }
    static get states() { return {
        "Attachment": {},
        "loading": {},
        "error": {}
    }; }
    static get elementRef() { return "host"; }
}
