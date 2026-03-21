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
            { typeof(void), "void" },
            { typeof(object), "object" }
        };
        public static bool IsList(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        public static bool HasAttribute<TAttribute>(this MemberInfo element, out TAttribute attribute) where TAttribute : class
        {
            attribute = element?.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            return attribute != null;
        }
        public static bool HasAttributeInConstructor<TAttribute>(this Type element, out TAttribute attribute) where TAttribute : class
        {
            attribute = null;

            ConstructorInfo constructor = element?.GetConstructors()
                .FirstOrDefault(constructor => constructor.HasAttribute<TAttribute>(out _));

            bool hasConstructor = constructor != null;

            if (hasConstructor)
                constructor.HasAttribute(out attribute);

            return hasConstructor;
        }
        public static bool IsProxyable(this Type type) => type.GetConstructors().Any(constructor => constructor.HasAttribute(out IProxyAttribute _));
        public static string GetProxyName(this Type type) => $"{type.Name}Proxy";
        public static string GetSafetyTypeName(this Type type)
        {
            if (_typeAlias.TryGetValue(type, out string key))
                return key;

            if (type.IsGenericParameter)
                return type.Name;

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return $"{Nullable.GetUnderlyingType(type).GetSafetyTypeName()}?";

            if (type.IsGenericType)
            {
                string name = type.Name.Split('`')[0];
                IEnumerable<string> args = type.GetGenericArguments().Select(type => type.GetSafetyTypeName());
                return $"{name}<{string.Join(", ", args)}>";
            }

            if (type.IsArray)
                return $"{type.GetElementType().GetSafetyTypeName()}[{new string(',', type.GetArrayRank() - 1)}]";

            if (type.IsProxyable())
                return type.GetProxyName();

            string typeName = type.Name;

            if (type.IsNested && type.DeclaringType != null)
                return $"{type.DeclaringType.GetSafetyTypeName()}.{typeName}";

            return typeName;
        }
    }
}
