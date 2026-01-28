using UnityEngine;

[RequireComponent(typeof(ITargetSetter))]
public class Item : MonoBehaviour, IPickable
{
    [SerializeField] private HingeJoint2D _holder1;
    [SerializeField] private HingeJoint2D _holder2;

    private ITargetSetter _targetTracker;

    private void Awake()
    {
        _targetTracker = GetComponent<ITargetSetter>();
    }
    private void Start()
    {
        Drop();
    }
    public void PickUp(Rigidbody2D hand1, Rigidbody2D hand2)
    {
        AlignHandsAndItems(hand1, hand2);

        Connect(_holder1, hand1);
        Connect(_holder2, hand2);

        //_targetTracker.SetTargetMousePosition();
    }
    private void AlignHandsAndItems(Rigidbody2D hand1, Rigidbody2D hand2)
    {
        Vector2 hand1Position = hand1.transform.position;
        Vector2 hand2Position = hand2.transform.position;

        Vector2 newPosition = Vector2.Lerp(hand1Position, hand2Position, 0.5f);

        if (_holder1)
            hand1.position = _holder1.transform.TransformPoint(_holder1.anchor);
        if (_holder2)
            hand2.position = _holder2.transform.TransformPoint(_holder2.anchor);
    }
    public void Drop()
    {
        //_targetTracker.ResetTarget();

        Disconnect(_holder1);
        Disconnect(_holder2);
    }
    private void Connect(HingeJoint2D holder, Rigidbody2D hand) => SetConnection(hand, holder);
    private void Disconnect(HingeJoint2D holder) => SetConnection(null, holder);
    private void SetConnection(Rigidbody2D hand, HingeJoint2D holder)
    {
        if (!holder)
            return;

        if (hand)
        {
            holder.connectedBody = hand;
            holder.enabled = true;
        }

        else
        {
            holder.enabled = false;
            holder.connectedBody = null;
        }
    }
}
