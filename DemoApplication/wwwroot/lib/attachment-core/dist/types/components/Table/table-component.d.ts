import { EventEmitter } from '../../stencil.core';
import { AttachmentItemPagedList, AttachmentKeyModel, AttachmentItemKeyModel, AttachmentItem } from '../../utils/Models';
export declare class TableComponent {
    deleteComfirmation: HTMLDeleteComfirmationElement;
    infoDialog: HTMLInfoDialogElement;
    create: HTMLAttachmentCreateElement;
    componentDidLoad(): void;
    onStartLoading: EventEmitter;
    onEndLoading: EventEmitter;
    pageItems: AttachmentItemPagedList;
    AttachmentKey: AttachmentKeyModel;
    Load(pageIndex: number, pageSize: number): Promise<AttachmentItemPagedList>;
    Refresh(): Promise<AttachmentItemPagedList>;
    getAttachmentItemKey(id: number): AttachmentItemKeyModel;
    delete(attachmentItem: AttachmentItem): void;
    download(attachmentItem: AttachmentItem): void;
    info(attachmentItem: AttachmentItem): void;
    renderDeleteButton(attachmentItem: AttachmentItem): any;
    renderDownloadButton(attachmentItem: AttachmentItem): any;
    renderInfoButton(attachmentItem: AttachmentItem): any;
    renderRows(): any[];
    render(): any[];
}
