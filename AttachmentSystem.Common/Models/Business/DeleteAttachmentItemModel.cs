using AttachmentSystem.Common.Models.Attachment;
using System.Collections.Generic;

namespace AttachmentSystem.Common.Models.Business
{
    public class DeleteAttachmentItemModel:AttachmentKeyModel
    {
        public int AttachmentId { get; set; }
        public List<int> AttachmentItemId { get; set; }
    }
}
