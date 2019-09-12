namespace AttachmentCore.Common.Models.Shared
{
    public interface IPagingOptions
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
    }
}
