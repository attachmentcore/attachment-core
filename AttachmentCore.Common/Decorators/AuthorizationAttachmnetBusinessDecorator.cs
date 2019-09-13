using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Models.AttachmentItemModels;
using AttachmentCore.Common.Models.AttachmentModels;
using System;

namespace AttachmentCore.Common.Decorators
{
    public class AuthorizationAttachmnetBusinessDecorator : IAttachmentBusiness
    {
        IAttachmentBusiness _business;
        IAttachmentAuthorization _authorization;
        public AuthorizationAttachmnetBusinessDecorator(IAttachmentBusiness business, IAttachmentAuthorization authorization) 
        {
            this._business = business;
            this._authorization = authorization;
        }

        //create
        public AttachmentModel CreateAttachment(AttachmentKeyModel model)
        {
            if (!_authorization.Create(model))
                throw new UnauthorizedAccessException();
            return _business.CreateAttachment(model);
        }
        //create
        public AttachmentModel CreateAttachmentTemporarily(TemporaryAttachmentKeyModel model)
        {
            if (!_authorization.Create(new AttachmentKeyModel { EntityName = model.EntityName, FieldName = model.FieldName }))
                throw new UnauthorizedAccessException();
            return _business.CreateAttachmentTemporarily(model);
        }
        //create
        public int PreserveAttachment(PreserveAttachmentModel model)
        {
            if (!_authorization.Create(new AttachmentKeyModel { EntityName = model.EntityName, FieldName = model.FieldName, EntityId = model.EntityId }))
                throw new UnauthorizedAccessException();
            return _business.PreserveAttachment(model);
        }
        //delete
        public void DeleteAttachmentItem(DeleteAttachmentItemModel model)
        {
            if (!_authorization.Remove(model))
                throw new UnauthorizedAccessException();
            _business.DeleteAttachmentItem(model);
        }
        //download
        public AttachmentItemDownloadModel DownloadAttachmentItem(AttachmentItemKeyModel model)
        {
            if (!_authorization.Download(model))
                throw new UnauthorizedAccessException();
            return _business.DownloadAttachmentItem(model);
        }
        //read
        public AttachmentItemPagedList GetAllAttachmentItems(AttachmentItemSearchModel searchModel)
        {
            if (!_authorization.Read(new AttachmentKeyModel { EntityName = searchModel.EntityName, FieldName = searchModel.FieldName, EntityId = searchModel.EntityId }))
                throw new UnauthorizedAccessException();
            return _business.GetAllAttachmentItems(searchModel);
        }
        //read
        public AttachmentModel GetAttachmentId(AttachmentKeyModel model)
        {
            if (!_authorization.Read(model))
                throw new UnauthorizedAccessException();
            return _business.GetAttachmentId(model);
        }
        //details
        public AttachmentItem GetAttachmentItem(AttachmentItemKeyModel model)
        {
            if (!_authorization.Details(model))
                throw new UnauthorizedAccessException();
            return _business.GetAttachmentItem(model);
        }
        //upload
        public void UploadAttachmentItem(UploadAttachmentItemModel model)
        {
            if (!_authorization.Upload(model))
                throw new UnauthorizedAccessException();
            _business.UploadAttachmentItem(model);
        }
    }
}
