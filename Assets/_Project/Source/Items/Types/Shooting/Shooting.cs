using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Space.Rotor2Provider;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public sealed class Shooting : BaseEntity, IPickable, IUsable
{
    public ItemHolder ItemHolder { get; private init; }

    private readonly IRigidbody2D _rigidbody2D;
    private readonly IShootingCalculator _shootingCalculator;
    private readonly IVector2Provider _shootDirection;
    private readonly IVector2Provider _shootPoint;
    private readonly ObjectPool _bulletsPool;
    private readonly Timer _cooldown;
    private readonly Timer _reloadCooldown;
    private readonly int _maxBulletsCount;
    private int _bullets;
    public Shooting(ItemHolder itemHolder, IRigidbody2D rigidbody2D, IShootingCalculator shootingDirectionCalculator, IVector2Provider shootDirection, IVector2Provider shootPoint, ObjectPool bulletsPool, Timer cooldown, Timer reloadCooldown, int maxBulletsCount)
    {
        ItemHolder = itemHolder;

        _rigidbody2D = rigidbody2D;
        _shootingCalculator = shootingDirectionCalculator;
        _shootDirection = shootDirection;
        _shootPoint = shootPoint;
        _bulletsPool = bulletsPool;
        _cooldown = cooldown;
        _reloadCooldown = reloadCooldown;
        _maxBulletsCount = maxBulletsCount;
    }
    public void Use()
    {
        if (!Enabled ||
            _cooldown.InCoolDown ||
            _reloadCooldown.InCoolDown ||
            !_shootPoint.TryGetSafety(out Vector2 shootPoint) ||
            !_shootDirection.TryGetSafety(out Vector2 shootDirection))
            return;

        _bullets++;

        if (_bullets >= _maxBulletsCount)
        {
            _reloadCooldown.SetCooldown();
            _bullets = 0;
        }

        IGameObject bullet = _bulletsPool.Spawn(shootPoint, new(shootDirection));
        bullet.Layer = ItemHolder.GameObject.Layer;

        if (bullet.MainComponent is IRigidbody2D bulletRigidbody2D)
        {
            bulletRigidbody2D.LinearVelocity = Vector2.Zero;
            bulletRigidbody2D.AngularVelocity = 0f;

            bulletRigidbody2D.AddForce(_shootingCalculator.GetBulletForce(shootDirection), ForceMode2D.Impulse);
        }

        if (_rigidbody2D.Exists())
            _rigidbody2D.AddForce(_shootingCalculator.GetRecoilForce(shootDirection), ForceMode2D.Impulse);

        _cooldown.SetCooldown();
    }
}
