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
    public abstract class AttachmentBusinessDecorator : IAttachmentBusiness
    {
        protected IAttachmentBusiness decoratedBusiness;
        public AttachmentBusinessDecorator(IAttachmentBusiness decoratedBusiness)
        {
            this.decoratedBusiness = decoratedBusiness;
        }
        
        public virtual AttachmentModel CreateAttachmentTemporarily(TemporaryAttachmentKeyModel model)
        {
            return this.decoratedBusiness.CreateAttachmentTemporarily(model);
        }
        public virtual int PreserveAttachment(PreserveAttachmentModel model)
        {
            return this.decoratedBusiness.PreserveAttachment(model);
        }
        public virtual AttachmentModel CreateAttachment(AttachmentKeyModel model)
        {
            return this.decoratedBusiness.CreateAttachment(model);
        }
        public virtual AttachmentModel GetAttachmentId(AttachmentKeyModel model)
        {
            return this.decoratedBusiness.GetAttachmentId(model);
        }
        public virtual AttachmentItemPagedList GetAllAttachmentItems(AttachmentItemSearchModel searchModel)
        {
            return this.decoratedBusiness.GetAllAttachmentItems(searchModel);
        }
        public virtual AttachmentItem GetAttachmentItem(GetAttachmentItemModel model)
        {
            return this.decoratedBusiness.GetAttachmentItem(model);
        }
        public virtual void UploadAttachmentItem(UploadAttachmentItemModel model)
        {
            this.decoratedBusiness.UploadAttachmentItem(model);
        }
        public virtual void DeleteAttachmentItem(DeleteAttachmentItemModel model)
        {
            this.decoratedBusiness.DeleteAttachmentItem(model);
        }

        public virtual AttachmentItem DownloadAttachmentItem(GetAttachmentItemModel model)
        {
            return this.decoratedBusiness.DownloadAttachmentItem(model);
        }
    }
}
