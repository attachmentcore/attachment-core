using System.Collections.Generic;
using AttachmentSystem.Common.Models.AttacmentModels;
using AttachmentSystem.Models.Common;
using IRISAES.AttachmentModule.Entity;

namespace AttachmentSystem.Common.Models.AttachmentItemModels
{
    public class AttachmentItemSearchModel : AttachmentKeyModel, IPagingOptions, ISortingOptions, IAttachmentItemSearchModel
    {
        public int? AttachmentId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IList<SortingOption> SortingOptions { get; set; }
    }
}


