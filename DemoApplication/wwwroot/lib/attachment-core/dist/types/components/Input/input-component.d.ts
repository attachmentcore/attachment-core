import { AttachmentBusiness } from '../../utils/Services';
import { AttachmentModel } from '../../utils/Models';
export declare class AttachmentInputComponent {
    modal: HTMLAttachmentModalElement;
    host: HTMLDivElement;
    attachmentBusiness: AttachmentBusiness;
    EntityName: string;
    FieldName: string;
    EntityId: string;
    Placeholder: string;
    BaseUrl: string;
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
