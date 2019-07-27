using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.Models.Common
{
    public interface IPagingOptions
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
    }
}
