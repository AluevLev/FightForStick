// AUTO-GENERATED. DO NOT EDIT.
[System.Serializable]
public class SpacePointProviderProxy : IPointProviderProxy
{
    [UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation] private IPointProviderProxy _pointProvider;
    [UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation] private IceFebruary.ITransform _space;
    public IceFebruary.Space.PointProvider.IPointProvider ToPoco() => new IceFebruary.Space.PointProvider.SpacePointProvider(_pointProvider?.ToPoco(), _space);
}
