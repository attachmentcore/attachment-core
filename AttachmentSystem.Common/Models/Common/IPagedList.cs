using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.Models.Common
{
     public interface IPagedList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalItemsCount { get; }
        IList<T> Items { get; }
    }
}
