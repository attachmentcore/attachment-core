using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Common.Models.AttachmentItemModels;
using AttachmentSystem.Common.Models.AttacmentModels;
using System;

namespace AttachmentSystem.Common.Decorators
{
    public class NoAuthorizationAttachmentBusiness : IAttachmentBusiness
    {
        public AttachmentModel CreateAttachment(AttachmentKeyModel model)
        {
            throw new NotImplementedException();
        }

        public AttachmentModel CreateAttachmentTemporarily(TemporaryAttachmentKeyModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteAttachmentItem(DeleteAttachmentItemModel model)
        {
            throw new NotImplementedException();
        }

        public AttachmentItemDownloadModel DownloadAttachmentItem(AttachmentItemKeyModel model)
        {
            throw new NotImplementedException();
        }

        public AttachmentItemPagedList GetAllAttachmentItems(AttachmentItemSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public AttachmentModel GetAttachmentId(AttachmentKeyModel model)
        {
            throw new NotImplementedException();
        }

        public AttachmentItem GetAttachmentItem(AttachmentItemKeyModel model)
        {
            throw new NotImplementedException();
        }

        public int PreserveAttachment(PreserveAttachmentModel model)
        {
            throw new NotImplementedException();
        }

        public void UploadAttachmentItem(UploadAttachmentItemModel attachmentItem)
        {
            throw new NotImplementedException();
        }
    }
}
