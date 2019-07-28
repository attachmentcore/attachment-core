using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AttachmentSystem.Common.Models.AttachmentItemModels
{
    public interface IAttachmentItemUploadModel
    {
        int AttachmentId { get; set; }
        List<IFormFile> FileContent { get; set; }
    }
}
