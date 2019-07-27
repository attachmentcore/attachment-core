using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.Models.AttachmentItem
{
    public interface IAttachmentItemUploadModel
    {
        int AttachmentId { get; set; }
        List<IFormFile> FileContent { get; set; }
    }
}
