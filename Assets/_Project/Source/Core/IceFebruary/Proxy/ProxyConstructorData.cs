namespace IceFebruary.Proxy
{
    using System;
    using System.Linq;
    using System.Reflection;

    public readonly struct ProxyConstructorData
    {
        public Type ClassProxy { get; private init; }
        public Type InheritProxy { get; private init; }
        public Type ReturnType { get; private init; }
        public ParameterInfo[] Parameters { get; private init; }
        public string Attribute { get; private init; }
        public ProxyConstructorData(Type classProxy, Type inheritType, Type returnType, string attribute)
        {
            ClassProxy = classProxy;
            InheritProxy = inheritType;
            ReturnType = returnType;
            Parameters = classProxy.GetConstructors()
                .First(constructor => constructor.HasAttribute(out IProxyAttribute _))
                .GetParameters();
            Attribute = attribute;
        }
    }
}
