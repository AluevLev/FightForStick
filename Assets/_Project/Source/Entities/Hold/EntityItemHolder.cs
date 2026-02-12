using UnityEngine;

public class EntityItemHolder : ITogglable, IItemHolder
{
    private readonly IHand[] _entityHands;
    public bool Enabled { get; set; }
    public EntityItemHolder(IHand[] entityHands)
    {
        _entityHands = entityHands;
    }
    public void PickUpItem(IPickable item)
    {
        if (!Enabled)
            return;

        HingeJoint2D[] holders = item.Holders;

        int connections = Mathf.Min(_entityHands.Length, holders.Length);

        for (int connection = 0; connection < connections; connection++)
            _entityHands[connection].Connect(holders[connection]);
    }
    public void DropItemInHand()
    {
        if (!Enabled)
            return;

        foreach (IHand hand in _entityHands)
            hand.Disconnect();
    }
}
