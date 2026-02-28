// AUTO-GENERATED. DO NOT EDIT.
using System;
using UnityEngine;

[Serializable]
public class DirectionPointProviderProxy : IPointProviderProxy
{
    [SerializeReference, InterfaceImplementation] private IPointProviderProxy _from;
    [SerializeReference, InterfaceImplementation] private IPointProviderProxy _to;

    public IPointProvider ToPoco() => new DirectionPointProvider(_from.ToPoco(), _to.ToPoco());
}
