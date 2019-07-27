using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AttachmentSystem.Models.AttachmentItem
{
    public class AttachmentItem
    {
        public int Id { get; set; }
        public int? AttachmentId { get; set; }
        public string FileName { get; set; }
        public int? FileSize { get; set; }
        public string FileExtension { get; set; }
        public string Description { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Owner { get; set; }
        public Stream FileContent { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
