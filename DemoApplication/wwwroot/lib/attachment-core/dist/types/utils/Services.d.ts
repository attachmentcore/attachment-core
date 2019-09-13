import { AttachmentItemUploadModel, AttachmentModel, AttachmentItemSearchModel, AttachmentItemPagedList, AttachmentItemKeyModel } from "./Models";
export declare class AttachmentBusiness {
    constructor(baseUrl: string);
    baseUrl: string;
    Upload(model: AttachmentItemUploadModel): Promise<Response>;
    GetAttachmentId(entityName: string, fieldName: string, entityId?: string): Promise<AttachmentModel>;
    GetAllAttachmentItems(model: AttachmentItemSearchModel): Promise<AttachmentItemPagedList>;
    Delete(model: AttachmentItemKeyModel): Promise<Response>;
    Download(model: AttachmentItemKeyModel): void;
}
