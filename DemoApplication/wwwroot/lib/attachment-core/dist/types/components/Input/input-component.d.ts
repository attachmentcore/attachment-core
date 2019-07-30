import { AttachmentModel } from '../../utils/Models';
export declare class AttachmentInputComponent {
    modal: HTMLAttachmentModalElement;
    host: HTMLDivElement;
    EntityName: string;
    FieldName: string;
    EntityId: string;
    Placeholder: string;
    Attachment: AttachmentModel;
    loading: boolean;
    error: boolean;
    openModal(): void;
    getAttachmentId(): void;
    renderIcon(): any;
    renderModal(): any;
    componentDidLoad(): void;
    render(): any[];
}
