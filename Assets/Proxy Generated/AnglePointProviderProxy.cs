// AUTO-GENERATED. DO NOT EDIT.
using System;
using UnityEngine;

[Serializable]
public class AnglePointProviderProxy : IPointProviderProxy
{
    [SerializeField] private float _angle;

    public IPointProvider ToPoco() => new AnglePointProvider(_angle);
}
