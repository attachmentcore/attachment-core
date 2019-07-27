using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentSystem.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static string CompleteMessages(this Exception exception)
        {
            string message = "";
            while (exception != null)
            {
                if (message.HasValue())
                    message += "\r\nInner Exception :\r\n";
                message += exception.Message;

                if (exception is ReflectionTypeLoadException)
                {
                    var loadException = (exception as ReflectionTypeLoadException);
                    if (loadException.LoaderExceptions != null && loadException.LoaderExceptions.Count() > 0)
                    {
                        message += "\r\nLoader Exception :\r\n";
                        message += loadException.LoaderExceptions.First().Message;
                    }
                }
                exception = exception.InnerException;
            }
            return message;
        }
        public static string CompleteStackTraces(this Exception exception)
        {
            string stackTrace = "";
            while (exception != null)
            {
                if (stackTrace.HasValue())
                    stackTrace += "\r\nInner Exception :\r\n";
                stackTrace += exception.StackTrace;
                exception = exception.InnerException;
            }
            return stackTrace;
        }
        
    }
}
