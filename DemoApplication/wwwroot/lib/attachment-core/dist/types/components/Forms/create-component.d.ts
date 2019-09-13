import { EventEmitter } from '../../stencil.core';
import { AttachmentBusiness } from '../../utils/Services';
import { AttachmentKeyModel } from '../../utils/Models';
export declare class CreateComponent {
    fileInput: HTMLInputElement;
    descriptionInput: HTMLInputElement;
    AttachmentKey: AttachmentKeyModel;
    AttachmentBusiness: AttachmentBusiness;
    onCreate: EventEmitter;
    onRequest: EventEmitter;
    files: FileList;
    description: string;
    renderCreate(): any;
    postAttachment(): void;
    render(): any[];
}
