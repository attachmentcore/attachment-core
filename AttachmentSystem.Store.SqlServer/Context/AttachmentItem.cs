namespace AttachmentSystem.Store.SqlServer.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AttachmentItem")]
    public partial class AttachmentItem
    {
        public int Id { get; set; }

        public int AttachmentId { get; set; }

        [Required]
        public string FileName { get; set; }

        public int? FileSize { get; set; }

        public string FileExtension { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UploadDate { get; set; }

        [StringLength(50)]
        public string Owner { get; set; }

        [Required]
        public byte[] FileContent { get; set; }

        public virtual Attachment Attachment { get; set; }
    }
}
