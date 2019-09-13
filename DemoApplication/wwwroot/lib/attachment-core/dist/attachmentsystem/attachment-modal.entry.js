import { f as registerInstance, e as h, h as getElement } from './attachmentsystem-9dcd5be0.js';
import { a as Tunnel } from './chunk-8899376d.js';

class ModalComponent {
    constructor(hostRef) {
        registerInstance(this, hostRef);
    }
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
        return h("a", { class: "button is-info spinner " + (this.loading ? "is-loading" : ""), onClick: () => this.load(this.pageItems.pageIndex, this.pageItems.pageSize) }, h("span", { class: "icon is-small" }, !this.loading ? [h("attachment-icon", { "icon-name": "reload" })] : []));
    }
    renderPager() {
        if (!this.pageItems)
            return;
        let first = 1;
        let last = Math.ceil(this.pageItems.totalItemsCount / this.pageItems.pageSize);
        let prev = this.pageItems.pageIndex - 1;
        let next = this.pageItems.pageIndex + 1;
        if (first != last)
            return (h("nav", { class: "pagination is-centered", role: "navigation", "aria-label": "pagination" }, h("ul", { class: "pagination-list" }, first < this.pageItems.pageIndex ? [h("li", null, h("a", { class: "pagination-link", "aria-label": "Goto page 1", onClick: () => { this.load(first, this.pageItems.pageSize); } }, first))] : [], first + 1 < prev ? [h("li", null, h("span", { class: "pagination-ellipsis" }, "\u2026"))] : [], first < prev ? [h("li", null, h("a", { class: "pagination-link", "aria-label": "Goto page 45", onClick: () => { this.load(prev, this.pageItems.pageSize); } }, prev))] : [], this.pageItems.totalItemsCount != 0 ? h("li", null, h("a", { class: "pagination-link is-current", "aria-label": "Page 46", "aria-current": "page" }, this.pageItems.pageIndex)) : [], last > next ? [h("li", null, h("a", { class: "pagination-link", "aria-label": "Goto page 47", onClick: () => { this.load(next, this.pageItems.pageSize); } }, next))] : [], last - 1 > next ? [h("li", null, h("span", { class: "pagination-ellipsis" }, "\u2026"))] : [], last > this.pageItems.pageIndex ? [h("li", null, " ", h("a", { class: "pagination-link", "aria-label": "Goto page 86", onClick: () => { this.load(last, this.pageItems.pageSize); } }, last))] : [])));
    }
    render() {
        let classNames = "";
        if (this.loading)
            classNames += " loading";
        return [
            h("attachment-popup", { class: classNames, ref: el => (this.popup = el) }, h("div", { class: "modal-card" }, h("header", { class: "modal-card-head" }, h("label", { class: "modal-card-title" }, "Attachments List")), h("section", { class: "modal-card-body " + (this.loading ? "disabled" : "") }, h("attachment-table", { ref: el => (this.table = el) })), h("footer", { class: "modal-card-foot" }, this.renderPager(), this.renderReloader()), h("button", { class: "modal-close is-large", onClick: () => this.popup.close(), "aria-label": "close" })))
        ];
    }
    get el() { return getElement(this); }
    static get style() { return "attachment-modal > attachment-popup > .modal > .modal-card > .modal-card-body.disabled {\n  pointer-events: none;\n  opacity: 0.7;\n}\nattachment-modal > attachment-popup > .modal > .modal-card > .modal-card-head {\n  padding: 5px;\n}\nattachment-modal > attachment-popup > .modal > .modal-card > .modal-card-head .modal-card-title {\n  padding-left: 15px;\n  padding-bottom: 10px;\n  padding-top: 10px;\n  font-size: 18px !important;\n  font-weight: bold;\n}\nattachment-modal > attachment-popup > .modal > .modal-card > .modal-card-foot {\n  padding: 5px;\n}\nattachment-modal > attachment-popup > .modal > .modal-card > .modal-card-foot ul {\n  padding-left: 15px;\n  list-style-type: none;\n}\nattachment-modal > attachment-popup > .modal > .modal-card > .modal-card-foot .button.spinner {\n  margin-left: auto;\n  margin-right: 15px;\n  -ms-flex-order: 2;\n  order: 2;\n}"; }
}
Tunnel.injectProps(ModalComponent, ['AttachmentKey']);

export { ModalComponent as attachment_modal };
