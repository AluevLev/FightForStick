namespace IceFebruary.Physics
{
    using IceFebruary.Space;

    public interface IHingeJoint2D : IComponent
    {
        Vector2 Anchor { get; set; }
        IRigidbody2D ConnectedBody { get; set; }
    }
}

