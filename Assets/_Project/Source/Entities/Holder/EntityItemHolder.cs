using IceFebruary;
using IceFebruary.Collections;
using IceFebruary.Physics;

public sealed class EntityItemHolder : IItemHolder
{
    private readonly IHand[] _entityHands;
    private readonly bool _entityHandsNotExists;
    public EntityItemHolder(IHand[] entityHands)
    {
        _entityHands = entityHands;
        _entityHandsNotExists = !_entityHands.Exists();
    }
    public void PickUpItem(IPickable item)
    {
        if (_entityHandsNotExists || !item.Exists())
            return;

        Component<IHingeJoint2D>[] holders = item.ItemHolder.Holders;

        if (!holders.Exists())
            return;

        for (int connection = 0; connection < Math.Min(_entityHands.Length, holders.Length); connection++)
        {
            IHand hand = _entityHands[connection];
            Component<IHingeJoint2D> holder = holders[connection];

            hand.Connect(holder);
        }
    }
    public void DropItemInHand()
    {
        if (_entityHandsNotExists)
            return;

        for (int index = 0; index < _entityHands.Length; index++)
            _entityHands[index].Disconnect();
    }
}
