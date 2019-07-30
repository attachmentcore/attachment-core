import { AttachmentItemPagedList, AttachmentKeyModel } from '../../utils/Models';
export declare class ModalComponent {
    el: HTMLElement;
    wrapper: HTMLDivElement;
    table: HTMLAttachmentTableElement;
    popup: HTMLAttachmentPopupElement;
    componentDidLoad(): void;
    AttachmentKey: AttachmentKeyModel;
    loading: boolean;
    opened: boolean;
    pageItems: AttachmentItemPagedList;
    open(): Promise<void>;
    close(): Promise<void>;
    load(index: number, pageSize: number): void;
    renderReloader(): any;
    renderPager(): any;
    render(): any[];
}
