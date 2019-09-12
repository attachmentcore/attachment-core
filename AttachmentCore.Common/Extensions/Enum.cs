using System;
using System.ComponentModel;
using System.Reflection;

namespace AttachmentCore.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fieldInfo.GetCustomAttributes
                (typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                ? attributes[0].Description
                : enumValue.ToString();
        }
    }
}
