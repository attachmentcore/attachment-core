namespace AttachmentSystem.Store.SqlServer.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Attachment")]
    public partial class Attachment
    {
        public Attachment()
        {
            AttachmentItems = new HashSet<AttachmentItem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string EntityName { get; set; }

        public string EntityId { get; set; }

        [Required]
        [StringLength(50)]
        public string FieldName { get; set; }

        [StringLength(50)]
        public string Token { get; set; }

        [InverseProperty("Attachment")]
        public virtual ICollection<AttachmentItem> AttachmentItems { get; set; }
    }
}
