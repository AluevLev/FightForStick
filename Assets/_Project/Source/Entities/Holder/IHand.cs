using UnityEngine;

public interface IHand
{
    void Connect(HingeJoint2D holder);
    void Disconnect();
}
