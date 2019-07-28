using AttachmentSystem.Common.Models.AttacmentModels;

namespace AttachmentSystem.Common.Models.AttachmentItemModels
{
    public class AttachmentItemKeyModel : AttachmentKeyModel
    {
        public int AttachmentId { get; set; }
        public int AttachmentItemId { get; set; }
    }
}
