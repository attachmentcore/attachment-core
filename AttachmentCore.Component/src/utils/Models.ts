//input models
export class AttachmentKeyModel {
  public attachmentId: number;
  public entityName: string
  public fieldName: string
  public entityId: string
}
export class AttachmentItemKeyModel extends AttachmentKeyModel {
  public attachmentItemId: number
}
export class AttachmentItemUploadModel extends AttachmentKeyModel{
  public description: string
  public fileContent: FileList
}
export class AttachmentItemSearchModel extends AttachmentKeyModel {
  public pageIndex: number;
  public pageSize: number;
}
//output models
export class AttachmentModel {
  public totalCount: number
  public attachmentId: number
}
export class AttachmentItemPagedList {
  public pageIndex: number;
  public pageSize: number;
  public totalItemsCount: number;
  public items: AttachmentItem[];
}
export class AttachmentItem {
  public id: number;
  public attachmentId: number;
  public fileName: string;
  public fileSize: number;
  public fileExtension: string;
  public description: string;
  public uploadDate: Date;
}
