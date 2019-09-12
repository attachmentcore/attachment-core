using AttachmentCore.Common.Models.AttachmentModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AttachmentCore.Common.Models.AttachmentItemModels
{
    public class UploadAttachmentItemModel : AttachmentKeyModel
    {
        public int AttachmentId { get; set; }
        public string Description { get; set; }
        public List<IFormFile> FileContent { get; set; }
    }
}
