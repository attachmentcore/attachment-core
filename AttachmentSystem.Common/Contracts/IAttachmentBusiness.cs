using AttachmentSystem.Common.Models.Attachment;
using AttachmentSystem.Common.Models.Business;
using AttachmentSystem.Models;
using AttachmentSystem.Models.AttachmentItem;
using IRISAES.AttachmentModule.Contracts;
using IRISAES.AttachmentModule.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AttachmentSystem.Common.Contracts
{
    public interface IAttachmentBusiness
    {
        //create permission
        AttachmentModel CreateAttachmentTemporarily(TemporaryAttachmentKeyModel model);
        //create permission
        int PreserveAttachment(PreserveAttachmentModel model);
        //Create permission
        AttachmentModel CreateAttachment(AttachmentKeyModel model);
        //Read Permission
        AttachmentModel GetAttachmentId(AttachmentKeyModel model);
        //Read Permission
        AttachmentItemPagedList GetAllAttachmentItems(AttachmentItemSearchModel searchModel);
        //Read and Download Permission
        AttachmentItem GetAttachmentItem(GetAttachmentItemModel model);
        //Upload Permission
        void UploadAttachmentItem(UploadAttachmentItemModel attachmentItem);
        //Remove
        void DeleteAttachmentItem(DeleteAttachmentItemModel model);
    }
}
