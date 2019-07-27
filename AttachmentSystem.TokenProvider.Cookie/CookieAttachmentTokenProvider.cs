using AttachmentSystem.Common.Contracts;
using Microsoft.AspNetCore.Http;
using System;

namespace AttachmentSystem.SessionProvider.Cookie
{
    public class CookieAttachmentTokenProvider : IAttachmentSessionProvider
    {
        private IHttpContextAccessor _httpContextAccessor;
        public CookieAttachmentTokenProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string CookieKeyName { get; set; } = "AttachmentToken";
        public string GetAttachmentToken()
        {
            string value;
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(CookieKeyName, out value);
            return value;
        }

        public string SetAttachmentToken()
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(10);
            var token = Guid.NewGuid().ToString();
            _httpContextAccessor.HttpContext.Response.Cookies.Append(CookieKeyName, token, option);
            return token;
        }
    }
}
