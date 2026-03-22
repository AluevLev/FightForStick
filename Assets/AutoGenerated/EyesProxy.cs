// AUTO-GENERATED. DO NOT EDIT.
[UnityEngine.CreateAssetMenu(fileName = "EyesProxy", menuName = "Proxy/Eyes")]
public class EyesProxy : UnityEngine.ScriptableObject
{
    [UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation] private IceFebruary.Render.ISprite _eye1;
    [UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation] private IceFebruary.Render.ISprite _eye2;
    public Eyes ToPoco() => new(_eye1, _eye2);
}
