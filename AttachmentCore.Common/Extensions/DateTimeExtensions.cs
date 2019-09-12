using System;

namespace AttachmentCore.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool HasValue(this DateTime? value)
        {
            return value.HasValue;
        }
        public static bool EqualsWith(this DateTime date1, DateTime date2)
        {
            return date1 == date2;
        }
        public static bool EqualsWith(this DateTime date1, DateTime? date2)
        {
            if (!date2.HasValue())
            {
                return false;
            }
            return date1 == date2;
        }
        public static bool EqualsWith(this DateTime? date1, DateTime? date2)
        {
            if (!date2.HasValue() && !date1.HasValue())
            {
                return true;
            }
            else if (!date2.HasValue() || !date1.HasValue())
            {
                return false;
            }
            return date1 == date2;
        }

    }
}
