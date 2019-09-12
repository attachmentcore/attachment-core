using AttachmentCore.Common.Models.AttachmentModels;
using System.Collections.Generic;

namespace AttachmentCore.Common.Models.AttachmentItemModels
{
    public class DeleteAttachmentItemModel : AttachmentKeyModel
    {
        public int AttachmentId { get; set; }
        public List<int> AttachmentItemId { get; set; }
    }
}
