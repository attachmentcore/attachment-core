import { f as registerInstance, g as createEvent, e as h } from './attachmentsystem-9dcd5be0.js';
import { a as Tunnel } from './chunk-8899376d.js';

class TableComponent {
    constructor(hostRef) {
        registerInstance(this, hostRef);
        this.onStartLoading = createEvent(this, "onStartLoading", 7);
        this.onEndLoading = createEvent(this, "onEndLoading", 7);
    }
    componentDidLoad() {
        this.create.addEventListener("onCreate", () => {
            this.Refresh().then((data) => {
                this.onEndLoading.emit(data);
            });
        });
        this.create.addEventListener("onRequest", () => {
            this.onStartLoading.emit({});
        });
        this.deleteComfirmation.addEventListener("onAccept", (event) => {
            this.onStartLoading.emit({});
            this.AttachmentBusiness.Delete(this.getAttachmentItemKey(event.detail.id)).then(() => {
                this.Refresh().then((data) => {
                    this.onEndLoading.emit(data);
                });
            });
        });
    }
    async Load(pageIndex, pageSize) {
        console.log(pageIndex, pageSize);
        if (pageIndex < 1)
            return;
        this.onStartLoading.emit({});
        return this.AttachmentBusiness.GetAllAttachmentItems({
            attachmentId: this.AttachmentKey.attachmentId,
            entityName: this.AttachmentKey.entityName,
            fieldName: this.AttachmentKey.fieldName,
            entityId: this.AttachmentKey.entityId,
            pageIndex: pageIndex,
            pageSize: pageSize
        }).then(data => {
            this.pageItems = data;
            this.onEndLoading.emit(data);
            return data;
        });
    }
    async Refresh() {
        return this.Load(this.pageItems.pageIndex, this.pageItems.pageSize)
            .then(data => {
            return data;
        });
    }
    getAttachmentItemKey(id) {
        return {
            attachmentId: this.AttachmentKey.attachmentId,
            entityName: this.AttachmentKey.entityName,
            fieldName: this.AttachmentKey.fieldName,
            entityId: this.AttachmentKey.entityId,
            attachmentItemId: id
        };
    }
    delete(attachmentItem) {
        this.deleteComfirmation.open(attachmentItem);
    }
    download(attachmentItem) {
        this.AttachmentBusiness.Download({
            attachmentId: this.AttachmentKey.attachmentId,
            entityName: this.AttachmentKey.entityName,
            fieldName: this.AttachmentKey.fieldName,
            entityId: this.AttachmentKey.entityId,
            attachmentItemId: attachmentItem.id
        });
    }
    info(attachmentItem) {
        this.infoDialog.open(attachmentItem);
    }
    renderDeleteButton(attachmentItem) {
        return (h("a", { class: "button is-danger is-small is-outlined ", onClick: () => this.delete(attachmentItem) }, h("span", { class: "icon is-small" }, h("attachment-icon", { "icon-name": "delete" }))));
    }
    renderDownloadButton(attachmentItem) {
        return (h("a", { class: "button is-primary is-small is-outlined ", onClick: () => { this.download(attachmentItem); } }, h("span", { class: "icon is-small" }, h("attachment-icon", { "icon-name": "download" }))));
    }
    renderInfoButton(attachmentItem) {
        return (h("a", { class: "button is-info is-small is-outlined ", onClick: () => this.info(attachmentItem) }, h("span", { class: "icon is-small" }, h("attachment-icon", { "icon-name": "details" }))));
    }
    renderRows() {
        if (this.pageItems)
            return this.pageItems.items.map((item, index) => {
                let id = ((this.pageItems.pageIndex - 1) * this.pageItems.pageSize) + index + 1;
                return (h("tr", null, h("td", { "data-column": "Id" }, id), h("td", { "data-column": "Name" }, item.fileName), h("td", { "data-column": "Description" }, item.description), h("td", { "data-column": "Operations" }, this.renderDownloadButton(item), this.renderInfoButton(item), this.renderDeleteButton(item))));
            });
    }
    render() {
        return [
            h("attachment-create", { "attachment-key": this.AttachmentKey, ref: el => (this.create = el) }),
            h("table", { class: "table is-bordered is-striped is-narrow is-hoverable is-fullwidth" }, h("thead", null, h("tr", null, h("th", { class: "id" }, "Id"), h("th", { class: "name" }, "Name"), h("th", { class: "description" }, "Description"), h("th", { class: "operations" }, "Operations"))), h("tbody", null, this.renderRows())),
            h("delete-comfirmation", { ref: el => this.deleteComfirmation = el }),
            h("info-dialog", { ref: el => this.infoDialog = el }),
        ];
    }
    static get style() { return "ul.pagination-list {\n  margin-top: 0;\n  margin-bottom: 0;\n}\n\ntable {\n  width: 100%;\n  border-collapse: collapse;\n  /*border: 2px solid #aaa;*/\n  table-layout: fixed;\n  width: 100%;\n  margin-bottom: 0 !important;\n}\n\ntable tr:last-child td:first-child {\n  border-bottom-left-radius: 4px;\n}\n\ntable tr:last-child td:last-child {\n  border-bottom-right-radius: 4px;\n}\n\n/* Zebra striping */\ntr:nth-of-type(odd) {\n  background: #eee;\n}\n\nth {\n  background: #6392f5;\n  color: white;\n  font-weight: normal;\n  padding: 7px;\n  /*border: 2px solid #aaa;*/\n  text-align: left;\n  font-size: 18px;\n}\nth.id {\n  width: 10%;\n  text-align: center !important;\n}\nth.name {\n  width: 30%;\n}\nth .description {\n  width: 40%;\n}\n\ntd {\n  padding: 5px;\n  border: 2px solid #aaa;\n  word-break: break-all;\n}\ntd[data-column=Id] {\n  text-align: center;\n}\ntd .button {\n  margin-right: 3px;\n}\n\n/* \nMax width before this PARTICULAR table gets nasty\nThis query will take effect for any screen smaller than 760px\nand also iPads specifically.\n*/\n\@media only screen and (max-width: 760px), (min-device-width: 768px) and (max-device-width: 1024px) {\n  table {\n    width: 100%;\n  }\n\n  th {\n    text-align: left;\n  }\n  th.id {\n    text-align: left !important;\n  }\n\n  td[data-column=Id] {\n    text-align: left;\n  }\n\n  /* Force table to not be like tables anymore */\n  thead, tbody, th, td, tr {\n    vertical-align: middle !important;\n    display: block;\n  }\n\n  /* Hide table headers (but not display: none;, for accessibility) */\n  thead tr {\n    position: absolute;\n    top: -9999px;\n    left: -9999px;\n  }\n\n  tr {\n    border: 1px solid #ccc;\n  }\n\n  td {\n    /* Behave  like a \"row\" */\n    border: none;\n    position: relative;\n    padding-left: 50% !important;\n  }\n\n  td:before {\n    /* Now like a table header */\n    position: absolute;\n    /* Top/left values mimic padding */\n    top: 6px;\n    left: 6px;\n    width: 45%;\n    padding-right: 10px;\n    white-space: nowrap;\n    /* Label the data */\n    content: attr(data-column);\n    color: #000;\n    font-weight: bold;\n  }\n}\n.pager {\n  padding: 5px;\n  border-bottom: 2px solid #aaa;\n  border-left: 2px solid #aaa;\n  border-right: 2px solid #aaa;\n}\n.pager span.page-numbers {\n  padding: 5px;\n  display: inline-block;\n  vertical-align: middle;\n}"; }
}
Tunnel.injectProps(TableComponent, ['AttachmentKey', 'AttachmentBusiness']);

export { TableComponent as attachment_table };
