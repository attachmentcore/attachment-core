using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Models.AttachmentItemModels;
using AttachmentCore.Common.Models.AttachmentModels;

namespace AttachmentCore.Common.Decorators
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
            return decoratedBusiness.CreateAttachmentTemporarily(model);
        }
        public virtual int PreserveAttachment(PreserveAttachmentModel model)
        {
            return decoratedBusiness.PreserveAttachment(model);
        }
        public virtual AttachmentModel CreateAttachment(AttachmentKeyModel model)
        {
            return decoratedBusiness.CreateAttachment(model);
        }
        public virtual AttachmentModel GetAttachmentId(AttachmentKeyModel model)
        {
            return decoratedBusiness.GetAttachmentId(model);
        }
        public virtual AttachmentItemPagedList GetAllAttachmentItems(AttachmentItemSearchModel searchModel)
        {
            return decoratedBusiness.GetAllAttachmentItems(searchModel);
        }
        public virtual AttachmentItem GetAttachmentItem(AttachmentItemKeyModel model)
        {
            return decoratedBusiness.GetAttachmentItem(model);
        }
        public virtual void UploadAttachmentItem(UploadAttachmentItemModel model)
        {
            decoratedBusiness.UploadAttachmentItem(model);
        }
        public virtual void DeleteAttachmentItem(DeleteAttachmentItemModel model)
        {
            decoratedBusiness.DeleteAttachmentItem(model);
        }
        public virtual AttachmentItemDownloadModel DownloadAttachmentItem(AttachmentItemKeyModel model)
        {
            return decoratedBusiness.DownloadAttachmentItem(model);
        }
    }
}
