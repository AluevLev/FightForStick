namespace UnityIceFebruary.AutoGeneration
{
    using IceFebruary.Proxy;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class UnityMatchComponentGenerator
    {
        private static readonly string _matchClassName = "UnityMatchComponent";
        private static readonly string _analogPlace = "ANALOG";
        private static readonly string _typePlace = "TYPE";
        private static List<Match> _analogAlias = new();
        public static void Generate(IEnumerable<Type> allTypes)
        {
            _analogAlias = allTypes.Select(type =>
            {
                bool has = type.HasAttribute(out UnityAnalog analog);
                return (Has: has, Type: type, Analog: analog);
            })
                .Where(data => data.Has)
                .Select(data => new Match(data.Type, data.Analog))
                .ToList();

            StringBuilder stringBuilder = new();

            stringBuilder.SetWarning();

            stringBuilder.AppendLine("using IceFebruary;");
            stringBuilder.AppendLine("using System;");
            stringBuilder.AppendLine("using System.Collections.Generic;");
            stringBuilder.AppendLine("using UnityEngine;");
            stringBuilder.AppendLine("using UnityIceFebruary.Components;");

            stringBuilder.AppendLine($"public static class {_matchClassName}");
            stringBuilder.SetStartBrace();
            stringBuilder.AppendLine("    public static readonly Dictionary<Type, Func<Component, IComponent>> FabricAliases = new()");
            stringBuilder.SetStartBrace(1);
            stringBuilder.SetFabricAliasElement();
            stringBuilder.AppendLine("    };");
            stringBuilder.AppendLine("    public static readonly Dictionary<Type, Type> UnityAnalogs = new()");
            stringBuilder.SetStartBrace(1);
            stringBuilder.SetUnityAnalogElement();
            stringBuilder.AppendLine("    };");
            stringBuilder.SetEndBrace();

            CSSaver.SaveCSFile(stringBuilder, _matchClassName);
        }
        public static void SetFabricAliasElement(this StringBuilder stringBuilder) => stringBuilder.SetPair(GetPair($"typeof({_analogPlace})", $"component => new {_typePlace}(({_analogPlace})component)"));
        public static void SetUnityAnalogElement(this StringBuilder stringBuilder) => stringBuilder.SetPair($"        {{ typeof({_typePlace}), typeof({_analogPlace}) }},");
        public static string GetPair(string key, string value) => $"        {{ {key}, {value} }},";
        public static void SetPair(this StringBuilder stringBuilder, string pairConstruction)
        {
            foreach (Match match in _analogAlias)
            {
                string typeName = match.TypeName;
                string analogName = match.AnalogName;

                stringBuilder.AppendLine(pairConstruction.Replace(_typePlace, typeName).Replace(_analogPlace, analogName));
            }
        }
    }
}
