using Microsoft.AspNetCore.Http;
using System;

namespace AttachmentCore.Common.Models.Configuration
{
    public class AttachmentAppBuilderOptions
    {
        public Func<HttpContext, bool> UseWhen { get; set; }
    }
}
