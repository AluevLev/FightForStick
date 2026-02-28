// AUTO-GENERATED. DO NOT EDIT.
using System;
using UnityEngine;

[Serializable]
public class TransformPointProviderProxy : IPointProviderProxy
{
    [SerializeField] private Transform _transform;

    public IPointProvider ToPoco() => new TransformPointProvider(_transform);
}
