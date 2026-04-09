namespace IceFebruary.Physics
{
    using IceFebruary.Space;

    public interface IHingeJoint2D
    {
        Vector2 Anchor { get; set; }
        IRigidbody2D ConnectedBody { get; set; }
    }
}

