using AttachmentCore.Common.Models.Shared;
using System.Collections.Generic;

namespace AttachmentCore.Common.Models.AttachmentItemModels
{
    public class AttachmentItemPagedList : IPagedList<AttachmentItem>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
        public IList<AttachmentItem> Items { get; set; }
    }
}