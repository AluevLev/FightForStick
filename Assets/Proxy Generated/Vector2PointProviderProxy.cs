// AUTO-GENERATED. DO NOT EDIT.
using System;
using UnityEngine;

[Serializable]
public class Vector2PointProviderProxy : IPointProviderProxy
{
    [SerializeField] private Vector2 _vector2;

    public IPointProvider ToPoco() => new Vector2PointProvider(_vector2);
}
