using IceFebruary.Space;

public sealed class ShootingDirectionCalculator : IShootingDirectionCalculator
{
	private readonly float _shootingForce;
	public ShootingDirectionCalculator(float shootingForce)
	{
		_shootingForce = shootingForce;
	}
	public Vector2 GetBulletForce(Vector2 direction) => direction * _shootingForce;
}
