namespace AttachmentCore.Common.Contracts
{
    public interface IAttachmentSessionProvider
    {
        string GetAttachmentToken();
        string SetAttachmentToken();
    }
}
