using IRISAES.AttachmentModule.Entity;
using Microsoft.AspNetCore.Http;
using System;

namespace IRISAES.AttachmentModule.Models
{ 
    public class AttachmentItemViewModel 
    {
        public int? Id { get; set; }

        public int? AttachmentId { get; set; }

        public string Name { get; set; }

        public string FileExtension { get; set; }

        public int? Size { get; set; }

        public string Description { get; set; }
               
        public DateTime? UploadDate { get; set; }
        
        public string UploadUser { get; set; }
              
        public IFormFile FileContent { get; set; }//instead of byte[], becuase in ajax it sent FormFile not byte[]
              
    }
}
