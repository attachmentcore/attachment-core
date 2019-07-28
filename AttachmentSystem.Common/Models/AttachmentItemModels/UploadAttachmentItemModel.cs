using AttachmentSystem.Common.Models.AttacmentModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AttachmentSystem.Common.Models.AttachmentItemModels
{
    public class UploadAttachmentItemModel : AttachmentKeyModel,IAttachmentItemUploadModel
    {
        public int AttachmentId { get; set; }
        public string Description { get; set; }
        public List<IFormFile> FileContent { get; set; }
    }
}
