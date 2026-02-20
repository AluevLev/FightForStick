using UnityEngine;
using System;

[Serializable]
public struct UnityDirectionPointProvider : IUnityPointProviderHolder
{
    [SerializeReference, InterfaceImplementation] private IUnityPointProviderHolder _from;
    [SerializeReference, InterfaceImplementation] private IUnityPointProviderHolder _to;
    public readonly IPointProvider GetProvider() => new DirectionPointProvider(_from.GetProvider(), _to.GetProvider());
}