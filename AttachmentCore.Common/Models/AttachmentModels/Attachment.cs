using AttachmentCore.Common.Models.AttachmentItemModels;
using System.Collections.Generic;

namespace AttachmentCore.Common.Models.AttachmentModels
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
