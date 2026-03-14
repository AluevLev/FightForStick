// AUTO-GENERATED. DO NOT EDIT.
using IceFebruary;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityIceFebruary.Components;
public static class UnityComponentConverter
{
    public static readonly Dictionary<Type, Func<Component, IComponent>> FabricAliases = new()
    {
        { typeof(Camera), c => new UnityCamera((Camera)c) }
    };
    public static readonly Dictionary<Type, Type> UnityAnalogs = new()
    {
        { typeof(UnityCamera), typeof(Camera) }
    };
}