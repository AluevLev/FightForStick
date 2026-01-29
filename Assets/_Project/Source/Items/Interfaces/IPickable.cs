using UnityEngine;

public interface IPickable
{
    void PickUp(Rigidbody2D hard1, Rigidbody2D hand2, IPointProvider target);
    void Drop();
}
