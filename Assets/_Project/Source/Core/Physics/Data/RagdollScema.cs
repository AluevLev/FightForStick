using IceFebruary.Proxy;

public readonly struct RagdollScema
{
    private readonly PhysicsLimbSettings _head;
    private readonly PhysicsLimbSettings _body;

    private readonly PhysicsLimbSettings _shoulder1;
    private readonly PhysicsLimbSettings _forearm1;
    private readonly PhysicsLimbSettings _hand1;

    private readonly PhysicsLimbSettings _shoulder2;
    private readonly PhysicsLimbSettings _forearm2;
    private readonly PhysicsLimbSettings _hand2;

    private readonly PhysicsLimbSettings _hip1;
    private readonly PhysicsLimbSettings _shin1;
    private readonly PhysicsLimbSettings _foot1;

    private readonly PhysicsLimbSettings _hip2;
    private readonly PhysicsLimbSettings _shin2;
    private readonly PhysicsLimbSettings _foot2;

    [Proxy]
    public RagdollScema(PhysicsLimbSettings head, PhysicsLimbSettings body,
        PhysicsLimbSettings shoulder1, PhysicsLimbSettings forearm1, PhysicsLimbSettings hand1,
        PhysicsLimbSettings shoulder2, PhysicsLimbSettings forearm2, PhysicsLimbSettings hand2,
        PhysicsLimbSettings hip1, PhysicsLimbSettings shin1, PhysicsLimbSettings foot1,
        PhysicsLimbSettings hip2, PhysicsLimbSettings shin2, PhysicsLimbSettings foot2)
    {
        _head = head; _body = body;
        _shoulder1 = shoulder1; _forearm1 = forearm1; _hand1 = hand1;
        _shoulder2 = shoulder2; _forearm2 = forearm2; _hand2 = hand2;
        _hip1 = hip1; _shin1 = shin1; _foot1 = foot1;
        _hip2 = hip2; _shin2 = shin2; _foot2 = foot2;
    }
    public RagdollScema(PhysicsLimbSettings[] limbs)
    {
        _head = limbs[0]; _body = limbs[1];
        _shoulder1 = limbs[2]; _forearm1 = limbs[3]; _hand1 = limbs[4];
        _shoulder2 = limbs[5]; _forearm2 = limbs[6]; _hand2 = limbs[7];
        _hip1 = limbs[8]; _shin1 = limbs[9]; _foot1 = limbs[10];
        _hip2 = limbs[11]; _shin2 = limbs[12]; _foot2 = limbs[13];
    }
    public PhysicsLimbSettings[] ToArray() => new PhysicsLimbSettings[]
    {
        _head, _body,
        _shoulder1, _forearm1, _hand1,
        _shoulder2, _forearm2, _hand2,
        _hip1, _shin1, _foot1,
        _hip2, _shin2, _foot2
    };
}