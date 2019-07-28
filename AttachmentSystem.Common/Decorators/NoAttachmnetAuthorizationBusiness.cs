using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Common.Models.AttachmentItemModels;
using AttachmentSystem.Common.Models.AttacmentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.Common.Decorators
{
    public class NoAttachmnetAuthorizationBusiness : IAttachmentAuthorization
    {
        public bool Create(AttachmentKeyModel model)
        {
            return true;
        }

        public bool Details(AttachmentItemKeyModel model)
        {
            return true;
        }

        public bool Download(AttachmentItemKeyModel model)
        {
            return true;
        }

        public bool Read(AttachmentKeyModel model)
        {
            return true;
        }

        public bool Remove(DeleteAttachmentItemModel model)
        {
            return true;
        }

        public bool Upload(UploadAttachmentItemModel model)
        {
            return true;
        }
    }
}
