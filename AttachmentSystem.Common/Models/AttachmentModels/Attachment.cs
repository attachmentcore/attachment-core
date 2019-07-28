using AttachmentSystem.Common.Models.AttachmentItemModels;
using System.Collections.Generic;

namespace AttachmentSystem.Common.Models.AttacmentModels
{
    public class Attachment
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string FieldName { get; set; }
        public string EntityId { get; set; }
        public virtual ICollection<AttachmentItem> AttachmentItems { get; set; }
    }
}
