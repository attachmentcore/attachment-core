using AttachmentSystem.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AttachmentSystem.Common.Decorators
{
    public class AuthorizationBusinessDecorator : BusinessDecorator<IAttachmentBusiness>
    {
        public AuthorizationBusinessDecorator(IAttachmentAuthorization attachmentAuthorization)
        {

        }

        public override void BeforeCall(MethodInfo methodInfo, object[] args)
        {
            if (methodInfo.Name == "GetAttachmentId")
                return;
            else
                throw new Exception("Access Denied");
        }

    }
}
