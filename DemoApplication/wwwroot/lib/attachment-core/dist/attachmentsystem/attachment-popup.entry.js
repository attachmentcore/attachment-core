import { f as registerInstance, g as createEvent, e as h, h as getElement } from './attachmentsystem-9dcd5be0.js';

class PopupComponent {
    constructor(hostRef) {
        registerInstance(this, hostRef);
        this.onOpen = createEvent(this, "onOpen", 7);
        this.onClose = createEvent(this, "onClose", 7);
    }
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
            h("div", { class: "modal", ref: el => this.wrapper = el }, h("div", { class: "modal-background", onClick: () => this.close() }), h("slot", null))
        ];
    }
    get el() { return getElement(this); }
    static get style() { return ""; }
}

export { PopupComponent as attachment_popup };
