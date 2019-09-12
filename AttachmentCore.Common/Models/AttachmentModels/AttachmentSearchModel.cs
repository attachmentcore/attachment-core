using AttachmentCore.Common.Models.Shared;
using System.Collections.Generic;

namespace AttachmentCore.Common.Models.AttachmentModels
{
    public class AttachmentSearchModel : IPagingOptions, ISortingOptions
    {
        public AttachmentSearchModel()
        {
        }
        public int? Id { get; set; }
        public string EntityName { get; set; }
        public string EntityId { get; set; }
        public string FieldName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IList<SortingOption> SortingOptions { get; set; }
    }
}


