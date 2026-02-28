// AUTO-GENERATED. DO NOT EDIT.
using System;
using UnityEngine;

[Serializable]
public class SpacePointProviderProxy : IPointProviderProxy
{
    [SerializeReference, InterfaceImplementation] private IPointProviderProxy _pointProvider;
    [SerializeField] private Transform _space;

    public IPointProvider ToPoco() => new SpacePointProvider(_pointProvider.ToPoco(), _space);
}
