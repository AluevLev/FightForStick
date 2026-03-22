// AUTO-GENERATED. DO NOT EDIT.
[System.Serializable]
public class DirectionPointProviderProxy : IPointProviderProxy
{
    [UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation] private IPointProviderProxy _from;
    [UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation] private IPointProviderProxy _to;
    public IceFebruary.Space.PointProvider.IPointProvider ToPoco() => new IceFebruary.Space.PointProvider.DirectionPointProvider(_from?.ToPoco(), _to?.ToPoco());
}
