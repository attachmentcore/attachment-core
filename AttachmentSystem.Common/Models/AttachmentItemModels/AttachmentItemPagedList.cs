using AttachmentSystem.Models.Common;
using System.Collections.Generic;

namespace AttachmentSystem.Common.Models.AttachmentItemModels
{
    public class AttachmentItemPagedList : IPagedList<AttachmentItem>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
        public IList<AttachmentItem> Items { get; set; }
    }
}