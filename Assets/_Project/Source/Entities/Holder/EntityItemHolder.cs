using IceFebruary;
using IceFebruary.Physics;

public sealed class EntityItemHolder : IItemHolder
{
    private readonly IHand[] _entityHands;
    public EntityItemHolder(IHand[] entityHands)
    {
        _entityHands = entityHands;
    }
    public void PickUpItem(IPickable item)
    {
        IComponent<IHingeJoint2D>[] holders = item.Holders;

        int connections = Math.Min(_entityHands.Length, holders.Length);

        for (int connection = 0; connection < connections; connection++)
            _entityHands[connection].Connect(holders[connection]);
    }
    public void DropItemInHand()
    {
        foreach (IHand hand in _entityHands)
            hand.Disconnect();
    }
}
