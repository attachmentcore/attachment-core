using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentSystem.Common.Extensions
{
    public static class BooleanExtensions
    {
        public static bool HasValue(this bool? value)
        {
            return value.HasValue;
        }
        public static bool EqualsWith(this bool value1, bool value2)
        {
            return value1 == value2;
        }
        public static bool EqualsWith(this bool value1, bool? value2)
        {
            if (!value2.HasValue())
            {
                return false;
            }
            return value1 == value2;
        }

        public static bool EqualsWith(this bool? value1, bool? value2)
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
