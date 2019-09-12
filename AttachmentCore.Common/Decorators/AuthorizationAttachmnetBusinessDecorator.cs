using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Models.AttachmentItemModels;
using AttachmentCore.Common.Models.AttachmentModels;
using System;

namespace AttachmentCore.Common.Decorators
{
    public class AuthorizationAttachmnetBusinessDecorator : AttachmentBusinessDecorator
    {
        IAttachmentAuthorization authorization;
        public AuthorizationAttachmnetBusinessDecorator(IAttachmentBusiness decoratedBusiness, IAttachmentAuthorization authorization) : base(decoratedBusiness)
        {
            this.authorization = authorization;
        }

        //create
        public override AttachmentModel CreateAttachment(AttachmentKeyModel model)
        {
            if (!authorization.Create(model))
                throw new UnauthorizedAccessException();
            return base.CreateAttachment(model);
        }
        //create
        public override AttachmentModel CreateAttachmentTemporarily(TemporaryAttachmentKeyModel model)
        {
            if (!authorization.Create(new AttachmentKeyModel { EntityName = model.EntityName, FieldName = model.FieldName }))
                throw new UnauthorizedAccessException();
            return base.CreateAttachmentTemporarily(model);
        }
        //create
        public override int PreserveAttachment(PreserveAttachmentModel model)
        {
            if (!authorization.Create(new AttachmentKeyModel { EntityName = model.EntityName, FieldName = model.FieldName, EntityId = model.EntityId }))
                throw new UnauthorizedAccessException();
            return base.PreserveAttachment(model);
        }
        //delete
        public override void DeleteAttachmentItem(DeleteAttachmentItemModel model)
        {
            if (!authorization.Remove(model))
                throw new UnauthorizedAccessException();
            base.DeleteAttachmentItem(model);
        }
        //download
        public override AttachmentItemDownloadModel DownloadAttachmentItem(AttachmentItemKeyModel model)
        {
            if (!authorization.Download(model))
                throw new UnauthorizedAccessException();
            return base.DownloadAttachmentItem(model);
        }
        //read
        public override AttachmentItemPagedList GetAllAttachmentItems(AttachmentItemSearchModel searchModel)
        {
            if (!authorization.Read(new AttachmentKeyModel { EntityName = searchModel.EntityName, FieldName = searchModel.FieldName, EntityId = searchModel.EntityId }))
                throw new UnauthorizedAccessException();
            return base.GetAllAttachmentItems(searchModel);
        }
        //read
        public override AttachmentModel GetAttachmentId(AttachmentKeyModel model)
        {
            if (!authorization.Read(model))
                throw new UnauthorizedAccessException();
            return base.GetAttachmentId(model);
        }
        //details
        public override AttachmentItem GetAttachmentItem(AttachmentItemKeyModel model)
        {
            if (!authorization.Details(model))
                throw new UnauthorizedAccessException();
            return base.GetAttachmentItem(model);
        }
        //upload
        public override void UploadAttachmentItem(UploadAttachmentItemModel model)
        {
            if (!authorization.Upload(model))
                throw new UnauthorizedAccessException();
            base.UploadAttachmentItem(model);
        }
    }
}
