using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string FieldName { get; set; }
        public string EntityId { get; set; }
        public virtual ICollection<AttachmentSystem.Models.AttachmentItem.AttachmentItem> AttachmentItems { get; set; }
    }
}
