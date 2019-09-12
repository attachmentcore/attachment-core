using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Models.AttachmentItemModels;
using AttachmentCore.Common.Models.AttachmentModels;

namespace AttachmentCore.Common.Decorators
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
