using AttachmentSystem.Common.Models.Attachment;

namespace AttachmentSystem.Common.Models.Business
{
    public class GetAttachmentItemModel:AttachmentKeyModel
    {
        public int AttachmentId { get; set; }
        public int AttachmentItemId { get; set; }
        //public bool IncludeFile { get; set; } = false;
        //public bool IncludeAttachment { get; set; } = false;
    }
}
