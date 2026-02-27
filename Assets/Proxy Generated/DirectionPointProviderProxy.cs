// AUTO-GENERATED. DO NOT EDIT.
using System;
using UnityEngine;

[Serializable]
public class DirectionPointProviderProxy
{
    [SerializeReference, InterfaceImplementation] private IPointProvider _from;
    [SerializeReference, InterfaceImplementation] private IPointProvider _to;
    public DirectionPointProvider ToPoco() => new(_from, _to);
}
