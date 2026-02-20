using UnityEngine;
using System;

[Serializable]
public struct UnityVector2PointProvider : IUnityPointProviderHolder
{
    [SerializeField] private Vector2 _vector2;
    public readonly IPointProvider GetProvider() => new Vector2PointProvider(_vector2);
}