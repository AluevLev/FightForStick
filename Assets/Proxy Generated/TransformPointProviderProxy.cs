// AUTO-GENERATED. DO NOT EDIT.
using System;
using UnityEngine;

[Serializable]
public class TransformPointProviderProxy : IPointProviderProxy
{
    [SerializeReference, InterfaceImplementation] private ITransform _transform;

    public IPointProvider ToPoco() => new TransformPointProvider(_transform);
}
