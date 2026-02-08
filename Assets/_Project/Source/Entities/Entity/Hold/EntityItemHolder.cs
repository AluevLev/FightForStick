using UnityEngine;

public class EntityItemHolder : ITogglable, IItemHolder
{
    private readonly IHand[] _entityHands;
    private IPickable _itemInHand;
    public bool Enabled { get; set; }
    public EntityItemHolder(IHand[] entityHands)
    {
        _entityHands = entityHands;
    }
    public void PickUpItem(IPickable item)
    {
        if (!Enabled)
            return;
        if (item == null)
            return;
        if (_itemInHand != null)
            DropItemInHand();

        HingeJoint2D[] holders = item.Holders;

        int connections = Mathf.Min(_entityHands.Length, holders.Length);

        for (int connection = 0; connection < connections; connection++)
            _entityHands[connection].Connect(holders[connection]);

        _itemInHand = item;
    }
    public void DropItemInHand()
    {
        if (_itemInHand == null)
            return;

        foreach (IHand hand in _entityHands)
            hand.Disconnect();

        _itemInHand = null;
    }
}
