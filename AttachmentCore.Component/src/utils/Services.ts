import { AttachmentItemUploadModel, AttachmentModel, AttachmentItemSearchModel, AttachmentItemPagedList, AttachmentItemKeyModel } from "./Models";
import { GetUrl, AddObjectToUrl } from "./utils";
export class AttachmentBusiness {
  constructor(baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  baseUrl: string;
  Upload(model: AttachmentItemUploadModel): Promise<Response> {
    if (!model)
      throw new Error("passed AttachmentItemUploadModel could not be null");
    console.log(model);
    var form_data = new FormData();
    form_data.append("attachmentId", model.attachmentId.toString());
    form_data.append("entityName", model.entityName.toString());
    form_data.append("fieldName", model.fieldName.toString());
    form_data.append("entityId", model.entityId.toString());
    form_data.append("description", model.description.toString());
    for (var i = 0; i < model.fileContent.length; i++)
      form_data.append("fileContent", model.fileContent[i]);
    return fetch(GetUrl('/Upload', this.baseUrl), { method: "POST", body: form_data });
  }
  GetAttachmentId(entityName: string, fieldName: string, entityId?: string): Promise<AttachmentModel> {
    let params = {
      EntityName: entityName,
      FieldName: fieldName,
      EntityId: entityId
    };
    var url = AddObjectToUrl(GetUrl('/GetAttachmentId', this.baseUrl), params);
    return fetch(url)
      .then(response => {
        if (!response.ok) {
          throw new Error(response.statusText)
        }
        return response.json() as Promise<AttachmentModel>
      });
  }
  GetAllAttachmentItems(model: AttachmentItemSearchModel): Promise<AttachmentItemPagedList> {
    var url = AddObjectToUrl(GetUrl('/GetAllAttachmentItems', this.baseUrl), model);
    return fetch(url)
      .then(response => {
        if (!response.ok) {
          throw new Error(response.statusText)
        }
        return response.json() as Promise<AttachmentItemPagedList>
      });
  }
  Delete(model: AttachmentItemKeyModel): Promise<Response> {
    var url = AddObjectToUrl(GetUrl('/Delete', this.baseUrl), model);
    return fetch(url, { method: "DELETE" })
      .then(response => {
        return response
      });
  }
  Download(model: AttachmentItemKeyModel) {
    var url = AddObjectToUrl(GetUrl('/Download', this.baseUrl), model);
    window.open(url, "_self")
  }
}


