using UnityEngine;
using System;

[Serializable]
public struct UnityAnglePrintProvider : IUnityPointProviderHolder
{
    [SerializeField] private float _angle;
    public readonly IPointProvider GetProvider() => new AnglePointProvider(_angle);
}