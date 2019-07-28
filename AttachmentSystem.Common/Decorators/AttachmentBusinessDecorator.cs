using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Common.Models.AttachmentItemModels;
using AttachmentSystem.Common.Models.AttacmentModels;

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
        public virtual AttachmentItem GetAttachmentItem(AttachmentItemKeyModel model)
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
        public virtual AttachmentItemDownloadModel DownloadAttachmentItem(AttachmentItemKeyModel model)
        {
            return this.decoratedBusiness.DownloadAttachmentItem(model);
        }
    }
}
