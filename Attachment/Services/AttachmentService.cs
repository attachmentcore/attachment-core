using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Common.Extensions;
using AttachmentSystem.Common.Models.AttacmentModels;
using System;

namespace AttachmentSystem.Services
{
    public class AttachmentService
    {
        private IAttachmentBusiness attachmentBusiness;
        private IAttachmentSessionProvider tokenProvider;

        public AttachmentService(IAttachmentBusiness attachmentBusiness, IAttachmentSessionProvider tokenProvider)
        {
            this.attachmentBusiness = attachmentBusiness;
            this.tokenProvider = tokenProvider;
        }
        /// <summary>
        /// Create new attachment ultimately
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="fieldName"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public int CreateAttachment(string entityName, string fieldName, string entityId)
        {
            return attachmentBusiness.CreateAttachment(new AttachmentKeyModel { EntityName = entityName, FieldName = fieldName, EntityId = entityName }).AttachmentId;
        }
        /// <summary>
        /// connect a temporarty atttachment to an actual entity id
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="fieldName"></param>
        /// <param name="token"></param>
        /// <param name="entityId"></param>
        /// <param name=""></param>
        /// <returns>attachmentId</returns>
        public int SetEntityId(string entityName, string fieldName, string entityId)
        {
            var token = tokenProvider.GetAttachmentToken();
            if (!token.HasValue())
                throw new NullReferenceException("Attachment token don't have value");
            return attachmentBusiness.PreserveAttachment(new PreserveAttachmentModel { EntityName = entityName, FieldName = fieldName, Token = token, EntityId = entityId });
        }
    }
}
