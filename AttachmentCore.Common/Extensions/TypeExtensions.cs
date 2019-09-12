using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AttachmentCore.Common.Extensions
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
            return baseType.GenericTypeIsAssignableFrom(genericType);
        }
        public static PropertyDescriptor GetKeyProperty(this Type type)
        {
            Expression<Func<PropertyDescriptor, bool>> p1 = p => p.Attributes.OfType<KeyAttribute>().Any();
            Expression<Func<PropertyDescriptor, bool>> p2 = p => p.Name == "Id";
            //Expression<Func<PropertyDescriptor, bool>> p3 = p => p.Name== string.Format("{0}Id", type.Name);
            Expression<Func<PropertyDescriptor, bool>>[] predicates = new Expression<Func<PropertyDescriptor, bool>>[] { p1, p2/*, p3*/};
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
        public static bool IsNumericType(this Type type)
        {
            type = type.GetUnderlyingType();
            Type[] types = new Type[] { typeof(byte), typeof(sbyte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float), typeof(double), typeof(decimal) };
            if (types.Contains(type))
                return true;

            return false;
        }
        public static bool IsDateTime(this Type type)
        {
            type = type.GetUnderlyingType();
            Type[] types = new Type[] { typeof(DateTime) };
            if (types.Contains(type))
                return true;

            return false;
        }
        public static bool IsBoolean(this Type type)
        {
            type = type.GetUnderlyingType();
            Type[] types = new Type[] { typeof(bool) };
            if (types.Contains(type))
                return true;

            return false;
        }
        public static bool IsGuid(this Type type)
        {
            type = type.GetUnderlyingType();
            Type[] types = new Type[] { typeof(Guid) };
            if (types.Contains(type))
                return true;

            return false;
        }
        public static bool IsString(this Type type)
        {
            type = type.GetUnderlyingType();
            Type[] types = new Type[] { typeof(string) };
            if (types.Contains(type))
                return true;

            return false;
        }
        public static bool IsNullableType(this Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }
        public static Type GetUnderlyingType(this Type type)
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
