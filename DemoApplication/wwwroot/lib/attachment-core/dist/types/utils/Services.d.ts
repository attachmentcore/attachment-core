import { AttachmentItemUploadModel, AttachmentModel, AttachmentItemSearchModel, AttachmentItemPagedList, AttachmentItemKeyModel } from "./Models";
export declare function Upload(model: AttachmentItemUploadModel): Promise<Response>;
export declare function GetAttachmentId(entityName: string, fieldName: string, entityId?: string): Promise<AttachmentModel>;
export declare function GetAllAttachmentItems(model: AttachmentItemSearchModel): Promise<AttachmentItemPagedList>;
export declare function Delete(model: AttachmentItemKeyModel): Promise<Response>;
export declare function Download(model: AttachmentItemKeyModel): void;
