using AttachmentCore.Common.Models.AttachmentModels;

namespace AttachmentCore.Common.Models.AttachmentItemModels
{
    public class AttachmentItemKeyModel : AttachmentKeyModel
    {
        public int AttachmentId { get; set; }
        public int AttachmentItemId { get; set; }
    }
}
