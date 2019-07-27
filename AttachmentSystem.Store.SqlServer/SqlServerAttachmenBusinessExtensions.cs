using AttachmentSystem.Common.Contracts;
using AttachmentSystem.Models.Common;
using AttachmentSystem.Store.SqlServer.Businesses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.AttachmentService
{
    public static class SqlServerAttachmenBusinessExtensions
    {
        public static void UseSqlServerAttachmenBusiness(this AttachmentServiceConfigurationOptions _this, string connectionString)
        {
            _this.services.AddScoped<IAttachmentBusiness>((s) => SqlServerAttachmenBusiness.SqlServerAttachmenBusinessFactory(connectionString));
        }
    }
}
