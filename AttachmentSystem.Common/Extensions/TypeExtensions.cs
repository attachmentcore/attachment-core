using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AttachmentSystem.Common.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsGenericType(this Type type)
        {
            //This is .Net 4.0 way: type.IsGenericTypeDefinition
            //Below is new way
            return type.GetTypeInfo().IsGenericType;
        }
     
        public static bool GenericTypeIsAssignableFrom(this Type genericType, Type givenType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            Type baseType = givenType.BaseType;
            if (baseType == null) return false;
            return GenericTypeIsAssignableFrom(baseType, genericType);
        }

        public static PropertyDescriptor GetKeyProperty(this Type type)
        {
            Expression<Func<PropertyDescriptor, bool>> p1 = p => p.Attributes.OfType<KeyAttribute>().Any();
            Expression<Func<PropertyDescriptor, bool>> p2 = p => p.Name== "Id";
            //Expression<Func<PropertyDescriptor, bool>> p3 = p => p.Name== string.Format("{0}Id", type.Name);
            Expression<Func<PropertyDescriptor, bool>>[] predicates = new Expression<Func<PropertyDescriptor, bool>>[] { p1 , p2/*, p3*/};
            PropertyDescriptor key = null;
            foreach (var item in predicates)
            {
                var predicate = item.Compile();
                key = TypeDescriptor.GetProperties(type).OfType<PropertyDescriptor>()
                         .Where(property => predicate(property))
                         .FirstOrDefault();
                if (key != null)
                    return key;
            }
            return key;
        }

        public static bool IsNumericType(this System.Type type)
        {
            type = GetUnderlyingType(type);
            System.Type[] types = new System.Type[] { typeof(System.Byte), typeof(System.SByte), typeof(System.Int16), typeof(System.UInt16), typeof(System.Int32), typeof(System.UInt32), typeof(System.Int64), typeof(System.UInt64), typeof(System.Single), typeof(System.Double), typeof(System.Decimal) };
            if (types.Contains(type))
                return true;

            return false;
        }
        public static bool IsDateTime(this System.Type type)
        {
            type = GetUnderlyingType(type);
            System.Type[] types = new System.Type[] { typeof(System.DateTime) };
            if (types.Contains(type))
                return true;

            return false;
        }
        public static bool IsBoolean(this System.Type type)
        {
            type = GetUnderlyingType(type);
            System.Type[] types = new System.Type[] { typeof(System.Boolean) };
            if (types.Contains(type))
                return true;

            return false;
        }
        public static bool IsGuid(this System.Type type)
        {
            type = GetUnderlyingType(type);
            System.Type[] types = new System.Type[] { typeof(System.Guid) };
            if (types.Contains(type))
                return true;

            return false;
        }
        public static bool IsString(this System.Type type)
        {
            type = GetUnderlyingType(type);
            System.Type[] types = new System.Type[] { typeof(System.String) };
            if (types.Contains(type))
                return true;

            return false;
        }
        public static bool IsNullableType(this System.Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }
        public static System.Type GetUnderlyingType(this Type type)
        {
            var returnValue = Nullable.GetUnderlyingType(type);
            if (returnValue == null)
                returnValue = type;

            return returnValue;
        }
        public static string TypeName(this Assembly assembly)
        {
            return assembly.GetName().Name;
        }

    }
}
