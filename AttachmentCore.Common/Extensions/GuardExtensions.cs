using System;

namespace AttachmentCore.Common.Extensions
{
    public static class GuardExtensions
    {
        /// <summary>
        /// Checks if the argument is null.
        /// </summary>
        public static void CheckArgumentIsNull(this object o, string name)
        {
            if (o == null)
                throw new ArgumentNullException(name);
        }
        public static void CheckArgumentIsNullOrEmpty(this string o, string name)
        {
            if (string.IsNullOrEmpty(o))
                throw new ArgumentNullException(name);
        }
        public static bool IsNullOrEmpty(this string o)
        {
            return string.IsNullOrEmpty(o);
        }

    }
}