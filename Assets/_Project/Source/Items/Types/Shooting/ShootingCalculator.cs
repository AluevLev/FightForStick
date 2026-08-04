using IceFebruary.Space;

public sealed class ShootingCalculator : IShootingCalculator
{
	private readonly float _shootingForce;
	private readonly float _recoilForce;
	public ShootingCalculator(float shootingForce, float recoilForce)
	{
		_shootingForce = shootingForce;
		_recoilForce = recoilForce;
	}
	public Vector2 GetBulletForce(Vector2 direction) => _shootingForce * direction;
	public Vector2 GetRecoilForce(Vector2 direction) => _recoilForce * direction;
}
