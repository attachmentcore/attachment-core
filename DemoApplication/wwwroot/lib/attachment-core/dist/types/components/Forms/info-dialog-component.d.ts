import { AttachmentItem } from '../../utils/Models';
export declare class InfoDialogComponent {
    wrapper: HTMLDivElement;
    popup: HTMLAttachmentPopupElement;
    attachmentItem: AttachmentItem;
    open(attachmentItem: AttachmentItem): Promise<void>;
    close(): Promise<void>;
    renderClose(): any;
    renderInfo(): any;
    render(): any[];
}
