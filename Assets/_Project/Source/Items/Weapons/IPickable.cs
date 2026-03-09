using IceFebruary.Components;
using UnityEngine;

public interface IPickable : IComponent
{
    HingeJoint2D[] Holders { get; }
}
