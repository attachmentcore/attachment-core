﻿using AttachmentSystem.Common.Models.AttachmentItemModels;
using AttachmentSystem.Common.Models.AttacmentModels;

namespace AttachmentSystem.Common.Contracts
{
    public interface IAttachmentAuthorization
    {
        bool Create(AttachmentKeyModel model);//entityName,fieldName,entityId
        bool Read(AttachmentKeyModel model);//attachmentId
        bool Upload(UploadAttachmentItemModel model);//attachmentId,fileform
        bool Remove(DeleteAttachmentItemModel model);//attachmentItemId
        bool Download(AttachmentItemKeyModel model);//attachmentItemId
        bool Details(AttachmentItemKeyModel model);//attachmentItemId
    }
}
