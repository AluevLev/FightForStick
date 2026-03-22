// AUTO-GENERATED. DO NOT EDIT.
[UnityEngine.CreateAssetMenu(fileName = "GrimaceLibraryProxy", menuName = "Proxy/GrimaceLibrary")]
public class GrimaceLibraryProxy : UnityEngine.ScriptableObject
{
    [UnityEngine.SerializeField] private EyesProxy[] _eyes;
    [UnityEngine.SerializeField] private MouthProxy[] _mouths;
    [UnityEngine.SerializeField] private Face _defaultFace;
    public GrimaceLibrary ToPoco() => new(System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(_eyes ?? new EyesProxy[0], x => x.ToPoco())), System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(_mouths ?? new MouthProxy[0], x => x.ToPoco())), _defaultFace);
}
