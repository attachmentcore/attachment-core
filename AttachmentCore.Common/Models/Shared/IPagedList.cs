using System.Collections.Generic;

namespace AttachmentCore.Common.Models.Shared
{
    public interface IPagedList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalItemsCount { get; }
        IList<T> Items { get; }
    }
}
