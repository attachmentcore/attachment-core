using System.Collections.Generic;

namespace AttachmentCore.Common.Models.Shared
{
    interface ISortingOptions
    {
        IList<SortingOption> SortingOptions { get; set; }
    }
}
