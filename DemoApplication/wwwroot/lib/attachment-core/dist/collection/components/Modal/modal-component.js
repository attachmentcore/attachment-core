import { h } from '@stencil/core';
import Tunnel from '../../utils/AttachmentKeyStateTunnel';
export class ModalComponent {
    componentDidLoad() {
        this.table.addEventListener("onStartLoading", () => {
            this.loading = true;
        });
        this.table.addEventListener("onEndLoading", (data) => {
            this.pageItems = data.detail;
            this.loading = false;
        });
    }
    async open() {
        this.load(1, 5);
        this.popup.open();
    }
    async close() {
        this.popup.close();
    }
    load(index, pageSize) {
        this.table.Load(index, pageSize).then((pageItems) => {
            this.pageItems = pageItems;
        });
    }
    renderReloader() {
        return h("a", { class: "button is-info spinner " + (this.loading ? "is-loading" : ""), onClick: () => this.load(this.pageItems.pageIndex, this.pageItems.pageSize) },
            h("span", { class: "icon is-small" }, !this.loading ? [h("attachment-icon", { "icon-name": "reload" })] : []));
    }
    renderPager() {
        if (!this.pageItems)
            return;
        let first = 1;
        let last = Math.ceil(this.pageItems.totalItemsCount / this.pageItems.pageSize);
        let prev = this.pageItems.pageIndex - 1;
        let next = this.pageItems.pageIndex + 1;
        if (first != last)
            return (h("nav", { class: "pagination is-centered", role: "navigation", "aria-label": "pagination" },
                h("ul", { class: "pagination-list" },
                    first < this.pageItems.pageIndex ? [h("li", null,
                            h("a", { class: "pagination-link", "aria-label": "Goto page 1", onClick: () => { this.load(first, this.pageItems.pageSize); } }, first))] : [],
                    first + 1 < prev ? [h("li", null,
                            h("span", { class: "pagination-ellipsis" }, "\u2026"))] : [],
                    first < prev ? [h("li", null,
                            h("a", { class: "pagination-link", "aria-label": "Goto page 45", onClick: () => { this.load(prev, this.pageItems.pageSize); } }, prev))] : [],
                    this.pageItems.totalItemsCount != 0 ? h("li", null,
                        h("a", { class: "pagination-link is-current", "aria-label": "Page 46", "aria-current": "page" }, this.pageItems.pageIndex)) : [],
                    last > next ? [h("li", null,
                            h("a", { class: "pagination-link", "aria-label": "Goto page 47", onClick: () => { this.load(next, this.pageItems.pageSize); } }, next))] : [],
                    last - 1 > next ? [h("li", null,
                            h("span", { class: "pagination-ellipsis" }, "\u2026"))] : [],
                    last > this.pageItems.pageIndex ? [h("li", null,
                            " ",
                            h("a", { class: "pagination-link", "aria-label": "Goto page 86", onClick: () => { this.load(last, this.pageItems.pageSize); } }, last))] : [])));
    }
    render() {
        let classNames = "";
        if (this.loading)
            classNames += " loading";
        return [
            h("attachment-popup", { class: classNames, ref: el => (this.popup = el) },
                h("div", { class: "modal-card" },
                    h("header", { class: "modal-card-head" },
                        h("label", { class: "modal-card-title" }, "Attachments List")),
                    h("section", { class: "modal-card-body " + (this.loading ? "disabled" : "") },
                        h("attachment-table", { ref: el => (this.table = el) })),
                    h("footer", { class: "modal-card-foot" },
                        this.renderPager(),
                        this.renderReloader()),
                    h("button", { class: "modal-close is-large", onClick: () => this.popup.close(), "aria-label": "close" })))
        ];
    }
    static get is() { return "attachment-modal"; }
    static get originalStyleUrls() { return {
        "$": ["modal-component.scss"]
    }; }
    static get styleUrls() { return {
        "$": ["modal-component.css"]
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
        "loading": {},
        "opened": {},
        "pageItems": {}
    }; }
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
Tunnel.injectProps(ModalComponent, ['AttachmentKey']);
