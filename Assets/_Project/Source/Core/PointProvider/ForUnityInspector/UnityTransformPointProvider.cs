using UnityEngine;
using System;

[Serializable]
public struct UnityTransformPointProvider : IUnityPointProviderHolder
{
    [SerializeField] private Transform _transform;
    public readonly IPointProvider GetProvider() => new TransformPointProvider(_transform);
}
