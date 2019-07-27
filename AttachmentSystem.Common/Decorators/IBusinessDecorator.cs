using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AttachmentSystem.Common.Decorators
{
    public interface IBusinessDecorator
    {
        void OnError(Exception exception, MethodInfo methodInfo = null);
        void AfterCall(MethodInfo methodInfo, object[] args, object result);
        void BeforeCall(MethodInfo methodInfo, object[] args);
    }
}
