using AttachmentSystem.Common.Contracts;
using System;
using System.Reflection;

namespace AttachmentSystem.Common.Decorators
{
    public class BusinessDecorator<TBusiness> : DispatchProxy
            where TBusiness : class
    {
        protected TBusiness business;

        protected sealed override object Invoke(MethodInfo targetMethod, object[] args)
        {
            try
            {
                BeforeCall(targetMethod, args);

                var result = targetMethod.Invoke(business, args);

                AfterCall(targetMethod, args, result);
                return result;
            }
            catch (Exception ex) when (ex is TargetInvocationException)
            {
                OnError(ex.InnerException ?? ex, targetMethod);
                throw ex.InnerException ?? ex;
            }
        }
        public static TBusiness GetDecorated<TDecorator>(TBusiness business) 
            where TDecorator : BusinessDecorator<TBusiness>
        {
            object proxy = Create<TBusiness, TDecorator>();
            
            ((TDecorator)proxy).business = business;

            return proxy as TBusiness;
        }

        public virtual void OnError(Exception exception, MethodInfo methodInfo = null)
        {
            return;
        }

        public virtual void AfterCall(MethodInfo methodInfo, object[] args, object result)
        {
            return;
        }

        public virtual void BeforeCall(MethodInfo methodInfo, object[] args)
        {
            return;
        }
    }
}
