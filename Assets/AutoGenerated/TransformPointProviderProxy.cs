// AUTO-GENERATED. DO NOT EDIT.
[System.Serializable]
public class TransformPointProviderProxy : IPointProviderProxy
{
    [UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation] private IceFebruary.ITransform _transform;
    public IceFebruary.Space.PointProvider.IPointProvider ToPoco() => new IceFebruary.Space.PointProvider.TransformPointProvider(_transform);
}
