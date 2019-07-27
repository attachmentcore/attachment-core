using IRISAES.AttachmentModule.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.Models.Common
{
    interface ISortingOptions
    {
        IList<SortingOption> SortingOptions { get; set; }
    }
}
