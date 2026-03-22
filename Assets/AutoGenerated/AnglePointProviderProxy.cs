// AUTO-GENERATED. DO NOT EDIT.
[System.Serializable]
public class AnglePointProviderProxy : IPointProviderProxy
{
    [UnityEngine.SerializeField] private float _angle;
    public IceFebruary.Space.PointProvider.IPointProvider ToPoco() => new IceFebruary.Space.PointProvider.AnglePointProvider(_angle);
}
