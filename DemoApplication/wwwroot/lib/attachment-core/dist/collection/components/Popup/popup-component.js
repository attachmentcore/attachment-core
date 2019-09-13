import { h } from '@stencil/core';
export class PopupComponent {
    componentDidLoad() {
    }
    async open() {
        this.onOpen.emit({});
        this.wrapper.classList.add("is-active");
        this.render();
    }
    async close() {
        this.onClose.emit({});
        this.wrapper.classList.remove("is-active");
    }
    render() {
        return [
            h("div", { class: "modal", ref: el => this.wrapper = el },
                h("div", { class: "modal-background", onClick: () => this.close() }),
                h("slot", null))
        ];
    }
    static get is() { return "attachment-popup"; }
    static get originalStyleUrls() { return {
        "$": ["popup-component.scss"]
    }; }
    static get styleUrls() { return {
        "$": ["popup-component.css"]
    }; }
    static get states() { return {
        "opened": {}
    }; }
    static get events() { return [{
            "method": "onOpen",
            "name": "onOpen",
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
            "method": "onClose",
            "name": "onClose",
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
    static get elementRef() { return "el"; }
}
