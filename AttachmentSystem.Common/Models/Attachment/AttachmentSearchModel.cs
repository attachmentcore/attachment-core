using AttachmentSystem.Models.Common;
using IRISAES.AttachmentModule.Contracts;
using IRISAES.AttachmentModule.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IRISAES.AttachmentModule.Models
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
 

