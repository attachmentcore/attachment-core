using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Common.Models.Attachment;
using AttachmentSystem.Common.Models.Business;
using AttachmentSystem.Models.AttachmentItem;
using IRISAES.AttachmentModule.Contracts;
using IRISAES.AttachmentModule.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AttachmentSystem.Common.Decorators
{
    public class AuthorizationAttachmnetBusinessDecorator : AttachmentBusinessDecorator
    {
        IAttachmentAuthorization authorization;
        public AuthorizationAttachmnetBusinessDecorator(IAttachmentBusiness decoratedBusiness,IAttachmentAuthorization authorization) : base(decoratedBusiness)
        {
            this.authorization = authorization;
        }

        public override AttachmentModel CreateAttachment(AttachmentKeyModel model)
        {
            return base.CreateAttachment(model);
        }

        public override AttachmentModel CreateAttachmentTemporarily(TemporaryAttachmentKeyModel model)
        {
            return base.CreateAttachmentTemporarily(model);
        }

        public override void DeleteAttachmentItem(DeleteAttachmentItemModel model)
        {
            base.DeleteAttachmentItem(model);
        }

        public override AttachmentItem DownloadAttachmentItem(GetAttachmentItemModel model)
        {
            return base.DownloadAttachmentItem(model);
        }

        public override AttachmentItemPagedList GetAllAttachmentItems(AttachmentItemSearchModel searchModel)
        {
            return base.GetAllAttachmentItems(searchModel);
        }

        public override AttachmentModel GetAttachmentId(AttachmentKeyModel model)
        {
            return base.GetAttachmentId(model);
        }

        public override AttachmentItem GetAttachmentItem(GetAttachmentItemModel model)
        {
            return base.GetAttachmentItem(model);
        }

        public override int PreserveAttachment(PreserveAttachmentModel model)
        {
            return base.PreserveAttachment(model);
        }

        public override void UploadAttachmentItem(UploadAttachmentItemModel model)
        {
            base.UploadAttachmentItem(model);
        }
    }
}
