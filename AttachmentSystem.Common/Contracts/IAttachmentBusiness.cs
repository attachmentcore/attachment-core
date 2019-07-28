using AttachmentSystem.Common.Models.AttachmentItemModels;
using AttachmentSystem.Common.Models.AttacmentModels;

namespace AttachmentSystem.Common.Contracts
{
    public interface IAttachmentBusiness
    {
        //Create permission
        AttachmentModel CreateAttachmentTemporarily(TemporaryAttachmentKeyModel model);
        //Create permission
        int PreserveAttachment(PreserveAttachmentModel model);
        //Create permission
        AttachmentModel CreateAttachment(AttachmentKeyModel model);
        //Read Permission
        AttachmentModel GetAttachmentId(AttachmentKeyModel model);
        //Read Permission
        AttachmentItemPagedList GetAllAttachmentItems(AttachmentItemSearchModel searchModel);
        //Details Permission
        AttachmentItem GetAttachmentItem(AttachmentItemKeyModel model);
        //Download Permission
        AttachmentItemDownloadModel DownloadAttachmentItem(AttachmentItemKeyModel model);
        //Upload Permission
        void UploadAttachmentItem(UploadAttachmentItemModel attachmentItem);
        //Remove Permission
        void DeleteAttachmentItem(DeleteAttachmentItemModel model);
    }
}
