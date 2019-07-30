import { EventEmitter } from '../../stencil.core';
import { AttachmentKeyModel } from '../../utils/Models';
export declare class CreateComponent {
    fileInput: HTMLInputElement;
    descriptionInput: HTMLInputElement;
    AttachmentKey: AttachmentKeyModel;
    onCreate: EventEmitter;
    onRequest: EventEmitter;
    files: FileList;
    description: string;
    renderCreate(): any;
    postAttachment(): void;
    render(): any[];
}
