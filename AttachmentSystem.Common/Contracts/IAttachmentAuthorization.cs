using AttachmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.Common.Contracts
{
    public interface IAttachmentAuthorization
    {
        bool Create(Attachment model);//entityName,fieldName,entityId
        bool Read(Attachment model);//attachmentId
        bool Upload(Attachment model);//attachmentId,fileform
        bool Remove(Attachment model);//attachmentItemId
        bool Download(Attachment model);//attachmentItemId
        bool Details(Attachment model);//attachmentItemId
    }
}
