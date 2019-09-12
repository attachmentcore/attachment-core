using AttachmentCore.Common.Contracts;
using AttachmentCore.Common.Models.Shared;
using AttachmentCore.Store.SqlServer.Business;
using Microsoft.Extensions.DependencyInjection;

namespace AttachmentCore.Store.SqlServer
{
    public static class SqlServerAttachmenBusinessExtensions
    {
        public static void UseSqlServerAttachmenBusiness(this AttachmentServiceConfigurationOptions _this, string connectionString)
        {
            _this.services.AddScoped<IAttachmentBusiness>((s) => SqlServerAttachmenBusiness.SqlServerAttachmenBusinessFactory(connectionString));
        }
    }
}
