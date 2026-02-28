// AUTO-GENERATED. DO NOT EDIT.
using System;
using UnityEngine;

[Serializable]
public class ScalePointProviderProxy : IPointProviderProxy
{
    [SerializeReference, InterfaceImplementation] private IPointProviderProxy _pointProvider;
    [SerializeField] private float _scale;

    public IPointProvider ToPoco() => new ScalePointProvider(_pointProvider.ToPoco(), _scale);
}
