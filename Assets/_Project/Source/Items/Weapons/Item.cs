using IceFebruary;
using IceFebruary.Physics;

public class Item : IPickable
{
    public Item(IHingeJoint2D[] holders, IGameObject gameObject)
    {
        Holders = holders;
        GameObject = gameObject;
    }
    public IHingeJoint2D[] Holders { get; init; }
    public bool Enabled { get; set; } = true;
    public IGameObject GameObject { get; init; }
}
