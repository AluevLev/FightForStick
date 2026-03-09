using IceFebruary;
using UnityEngine;

public class Item : IPickable
{
    private readonly HingeJoint2D[] _holders;
    public Item(HingeJoint2D[] holders, IGameObject gameObject)
    {
        _holders = holders;
        GameObject = gameObject;
    }
    public HingeJoint2D[] Holders => _holders;
    public bool Enabled { get; set; } = true;
    public IGameObject GameObject { get; init; }
}
