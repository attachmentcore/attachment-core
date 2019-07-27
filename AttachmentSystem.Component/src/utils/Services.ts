import { AttachmentItemUploadModel, AttachmentModel, AttachmentItemSearchModel, AttachmentItemPagedList, AttachmentItemKeyModel } from "./Models";
import { GetUrl, AddObjectToUrl } from "./utils";

export function Upload(model: AttachmentItemUploadModel): Promise<Response> {
  if (!model)
    throw new Error("passed AttachmentItemUploadModel could not be null");

  var form_data = new FormData();
  form_data.append("attachmentId", model.attachmentId.toString());
  form_data.append("entityName", model.entityName.toString());
  form_data.append("fieldName", model.fieldName.toString());
  form_data.append("entityId", model.entityId.toString());
  form_data.append("description", model.description.toString());
  for (var i = 0; i < model.fileContent.length; i++)
    form_data.append("fileContent", model.fileContent[i]);
  return fetch(GetUrl('/Attachment/Upload'), { method: "POST", body: form_data });
}
export function GetAttachmentId(entityName: string, fieldName: string, entityId?: string): Promise<AttachmentModel> {
  let params = {
    EntityName: entityName,
    FieldName: fieldName,
    EntityId: entityId
  };

  var url = AddObjectToUrl(GetUrl('/Attachment/GetAttachmentId'), params);
  return fetch(url)
    .then(response => {
      if (!response.ok) {
        throw new Error(response.statusText)
      }
      return response.json() as Promise<AttachmentModel>
    });
}
export function GetAllAttachmentItems(model: AttachmentItemSearchModel): Promise<AttachmentItemPagedList> {
  var url = AddObjectToUrl(GetUrl('/Attachment/GetAllAttachmentItems'), model);
  return fetch(url)
    .then(response => {
      if (!response.ok) {
        throw new Error(response.statusText)
      }
      return response.json() as Promise<AttachmentItemPagedList>
    });
}
export function Delete(model : AttachmentItemKeyModel): Promise<Response> {
  var url = AddObjectToUrl(GetUrl('/Attachment/Delete'), model);
  return fetch(url, { method: "DELETE" })
    .then(response => {
      return response
    });
}
export function Download(model: AttachmentItemKeyModel) {
  var url = AddObjectToUrl(GetUrl('/Attachment/Download'), model);
  window.open(url, "_self")
}

