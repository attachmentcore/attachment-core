import { EventEmitter } from '../../stencil.core';
import { AttachmentItem } from '../../utils/Models';
export declare class DeleteComfirmationComponent {
    popup: HTMLAttachmentPopupElement;
    onAccept: EventEmitter;
    onCancel: EventEmitter;
    attachmentItem: AttachmentItem;
    open(attachmentItem: AttachmentItem): Promise<void>;
    close(): Promise<void>;
    accept(attachmentItem: AttachmentItem): void;
    cancel(attachmentItem: AttachmentItem): void;
    renderAccept(): any;
    renderCancel(): any;
    renderInfo(): any;
    render(): any[];
}
