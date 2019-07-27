using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentSystem.Models.Common
{
    public class AttachmentAppBuilderOptions
    {
        public Func<HttpContext, bool> UseWhen { get; set; }
    }
}
