using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.Common.Contracts
{
    public interface IAttachmentSessionProvider
    {
        string GetAttachmentToken();
        string SetAttachmentToken();
    }
}
