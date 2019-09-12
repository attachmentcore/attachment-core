using System.Collections.Generic;
using AttachmentCore.Common.Models.AttachmentModels;
using AttachmentCore.Common.Models.Shared;

namespace AttachmentCore.Common.Models.AttachmentItemModels
{
    public class AttachmentItemSearchModel : AttachmentKeyModel, IPagingOptions, ISortingOptions
    {
        public int? AttachmentId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IList<SortingOption> SortingOptions { get; set; }
    }
}


