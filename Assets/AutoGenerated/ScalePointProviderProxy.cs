// AUTO-GENERATED. DO NOT EDIT.
[System.Serializable]
public class ScalePointProviderProxy : IPointProviderProxy
{
    [UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation] private IPointProviderProxy _pointProvider;
    [UnityEngine.SerializeField] private float _scale;
    public IceFebruary.Space.PointProvider.IPointProvider ToPoco() => new IceFebruary.Space.PointProvider.ScalePointProvider(_pointProvider.ToPoco(), _scale);
}
