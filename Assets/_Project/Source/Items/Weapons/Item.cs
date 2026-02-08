using UnityEngine;

public class Item : IPickable
{
    private readonly HingeJoint2D[] _holders;
    public HingeJoint2D[] Holders => _holders;
    public Item(HingeJoint2D[] holders)
    {
        _holders = holders;
    }
}
