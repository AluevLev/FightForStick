namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityEngine;

    public abstract class UnityInfo : MonoBehaviour
    {
        public abstract IRootConfig ToPoco();
    }
}
