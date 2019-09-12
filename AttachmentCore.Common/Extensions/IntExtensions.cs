using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentCore.Common.Extensions
{
    public static class IntExtensions
    {
        public static bool HasValue(this int? value)
        {
            return value.HasValue && value.Value != 0;
        }
        public static bool HasValue(this int value)
        {
            return value != 0;
        }
        public static bool EqualsWith(this int value1, int value2)
        {
            return value1 == value2;
        }
        public static bool EqualsWith(this int value1, int? value2)
        {
            if (!value2.HasValue())
            {
                return false;
            }
            return value1 == value2;
        }
        public static bool EqualsWith(this int? value1, int? value2)
        {
            if (!value2.HasValue() && !value1.HasValue())
            {
                return true;
            }
            else if (!value2.HasValue() || !value1.HasValue())
            {
                return false;
            }
            return value1 == value2;
        }
    }
}
