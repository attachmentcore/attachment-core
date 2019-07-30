export declare class AttachmentKeyModel {
    attachmentId: number;
    entityName: string;
    fieldName: string;
    entityId: string;
}
export declare class AttachmentItemKeyModel extends AttachmentKeyModel {
    attachmentItemId: number;
}
export declare class AttachmentItemUploadModel extends AttachmentKeyModel {
    description: string;
    fileContent: FileList;
}
export declare class AttachmentItemSearchModel extends AttachmentKeyModel {
    pageIndex: number;
    pageSize: number;
}
export declare class AttachmentModel {
    totalCount: number;
    attachmentId: number;
}
export declare class AttachmentItemPagedList {
    pageIndex: number;
    pageSize: number;
    totalItemsCount: number;
    items: AttachmentItem[];
}
export declare class AttachmentItem {
    id: number;
    attachmentId: number;
    fileName: string;
    fileSize: number;
    fileExtension: string;
    description: string;
    uploadDate: Date;
}
