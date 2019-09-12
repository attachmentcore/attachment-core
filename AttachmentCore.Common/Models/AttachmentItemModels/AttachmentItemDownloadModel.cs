using System.IO;

namespace AttachmentCore.Common.Models.AttachmentItemModels
{
    public class AttachmentItemDownloadModel
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public Stream FileContent { get; set; }
    }
}
