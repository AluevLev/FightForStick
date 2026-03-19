namespace IceFebruary.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class ProxyTypeExtensions
    {
        private static readonly Dictionary<Type, string> _typeAlias = new()
        {
            { typeof(bool), "bool" },
            { typeof(byte), "byte" },
            { typeof(char), "char" },
            { typeof(decimal), "decimal" },
            { typeof(double), "double" },
            { typeof(float), "float" },
            { typeof(int), "int" },
            { typeof(long), "long" },
            { typeof(sbyte), "sbyte" },
            { typeof(short), "short" },
            { typeof(string), "string" },
            { typeof(uint), "uint" },
            { typeof(ulong), "ulong" },
            { typeof(ushort), "ushort" },
            { typeof(void), "void" }
        };
        public static bool IsList(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        public static bool HasAttribute<TAttribute>(this MemberInfo element, out TAttribute attribute) where TAttribute : class
        {
            attribute = element?.GetCustomAttributes().OfType<TAttribute>().FirstOrDefault();
            return attribute != null;
        }
        public static bool IsProxyable(this Type type) => type.GetConstructors().Any(constructor => constructor.HasAttribute(out IProxyAttribute _));
        public static string GetProxyName(this Type type) => $"{type.Name}Proxy";
        public static string GetSafetyTypeName(this Type type)
        {
            if (_typeAlias.TryGetValue(type, out string alias))
                return alias;

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return $"{Nullable.GetUnderlyingType(type).GetSafetyTypeName()}?";

            if (type.IsGenericType)
            {
                string name = type.Name.Split('`')[0];
                IEnumerable<string> args = type.GetGenericArguments().Select(t => t.GetSafetyTypeName());
                return $"{name}<{string.Join(", ", args)}>";
            }

            if (type.IsArray)
                return $"{type.GetElementType().GetSafetyTypeName()}[]";

            if (type.IsProxyable())
                return type.GetProxyName();

            return type.IsNested ? $"{type.DeclaringType.GetSafetyTypeName()}.{type.Name}" : type.Name;
        }
    }
}
