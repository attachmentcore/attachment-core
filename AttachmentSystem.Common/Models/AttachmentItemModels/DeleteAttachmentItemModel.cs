using AttachmentSystem.Common.Models.AttacmentModels;
using System.Collections.Generic;

namespace AttachmentSystem.Common.Models.AttachmentItemModels
{
    public class DeleteAttachmentItemModel : AttachmentKeyModel
    {
        public int AttachmentId { get; set; }
        public List<int> AttachmentItemId { get; set; }
    }
}
