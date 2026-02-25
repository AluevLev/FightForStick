using UnityEngine;
using System;

[Serializable]
public struct UnitySpacePointProvider : IUnityPointProviderHolder
{
    [SerializeReference, InterfaceImplementation] private IUnityPointProviderHolder _pointProvider;
    [SerializeField] private Transform _space;
    public readonly IPointProvider GetProvider() => new SpacePointProvider(_pointProvider.GetProvider(), _space);
}