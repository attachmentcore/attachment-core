using AttachmentSystem.Models;
using AttachmentSystem.Models.AttachmentItem;
using AttachmentSystem.Models.Common;
using System.Collections.Generic;

namespace IRISAES.AttachmentModule.Contracts
{
    public class AttachmentItemPagedList : IPagedList<AttachmentItem>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
        public IList<AttachmentItem> Items { get; set; }
    }
}