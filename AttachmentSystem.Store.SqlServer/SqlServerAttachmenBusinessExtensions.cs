using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Models.Common;
using AttachmentSystem.Store.SqlServer.Businesses;
using Microsoft.Extensions.DependencyInjection;

namespace AttachmentSystem.Store.SqlServer
{
    public static class SqlServerAttachmenBusinessExtensions
    {
        public static void UseSqlServerAttachmenBusiness(this AttachmentServiceConfigurationOptions _this, string connectionString)
        {
            _this.services.AddScoped<IAttachmentBusiness>((s) => SqlServerAttachmenBusiness.SqlServerAttachmenBusinessFactory(connectionString));
        }
    }
}
