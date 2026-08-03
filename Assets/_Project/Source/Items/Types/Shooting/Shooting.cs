using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public sealed class Shooting : BaseEntity, IPickable, IUsable
{
    public ItemHolder ItemHolder { get; private init; }

    private readonly IShootingDirectionCalculator _shootingDirectionCalculator;
    private readonly IVector2Provider _shootDirection;
    private readonly IVector2Provider _shootPoint;
    private readonly ObjectPool _bulletsPool;
    private readonly Timer _cooldown;
    public Shooting(ItemHolder itemHolder, IShootingDirectionCalculator shootingDirectionCalculator, IVector2Provider shootDirection, IVector2Provider shootPoint, ObjectPool bulletsPool, Timer cooldown)
    {
        ItemHolder = itemHolder;

        _shootingDirectionCalculator = shootingDirectionCalculator;
        _shootDirection = shootDirection;
        _shootPoint = shootPoint;
        _bulletsPool = bulletsPool;
        _cooldown = cooldown;
    }
    public void Use()
    {
        if (_cooldown.InCoolDown || !_shootPoint.TryGetSafety(out Vector2 shootPoint) || !_shootDirection.TryGetSafety(out Vector2 shootDirection))
            return;

        IGameObject bullet = _bulletsPool.Spawn(shootPoint);

        if (bullet.MainComponent.Value is IRigidbody2D rigidbody2D)
            rigidbody2D.AddForce(_shootingDirectionCalculator.GetBulletForce(shootDirection), ForceMode2D.Force);

        _cooldown.SetCooldown();
    }
}
