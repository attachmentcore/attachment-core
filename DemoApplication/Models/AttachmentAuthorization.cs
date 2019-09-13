using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Models.AttachmentItemModels;
using AttachmentCore.Common.Models.AttachmentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Models
{
    public class AttachmentAuthorization : IAttachmentAuthorization
    {
        public bool Create(AttachmentKeyModel model)
        {
            throw new NotImplementedException();
        }

        public bool Details(AttachmentItemKeyModel model)
        {
            throw new NotImplementedException();
        }

        public bool Download(AttachmentItemKeyModel model)
        {
            throw new NotImplementedException();
        }

        public bool Read(AttachmentKeyModel model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(DeleteAttachmentItemModel model)
        {
            throw new NotImplementedException();
        }

        public bool Upload(UploadAttachmentItemModel model)
        {
            throw new NotImplementedException();
        }
    }
}
