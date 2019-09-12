using Microsoft.AspNetCore.Http;
using System;

namespace AttachmentCore.Common.Models.Shared
{
    public class AttachmentAppBuilderOptions
    {
        public Func<HttpContext, bool> UseWhen { get; set; }
    }
}
