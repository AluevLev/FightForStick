using System;
using UnityEngine;

[Serializable]
public struct UnityScalePointProvider : IUnityPointProviderHolder
{
	[SerializeReference, InterfaceImplementation] private IUnityPointProviderHolder _pointProvider;
	[SerializeField] private float _scale;
	public readonly IPointProvider GetProvider() => new ScalePointProvider(_pointProvider.GetProvider(), _scale);
}
