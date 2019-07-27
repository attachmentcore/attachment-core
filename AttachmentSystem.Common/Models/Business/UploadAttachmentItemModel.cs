using AttachmentSystem.Common.Models.Attachment;
using AttachmentSystem.Models.AttachmentItem;
using IRISAES.AttachmentModule.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace IRISAES.AttachmentModule.Models
{ 
    public class UploadAttachmentItemModel : AttachmentKeyModel,IAttachmentItemUploadModel
    {
        public int AttachmentId { get; set; }
        public string Description { get; set; }
        public List<IFormFile> FileContent { get; set; }
    }
}
