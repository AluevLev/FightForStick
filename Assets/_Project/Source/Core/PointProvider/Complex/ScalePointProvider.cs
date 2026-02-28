using UnityEngine;

public class ScalePointProvider : IPointProvider
{
	private readonly IPointProvider _pointProvider;
	private readonly float _scale;
    [GenerateProxy(typeof(IPointProvider))]
    public ScalePointProvider(IPointProvider pointProvider, float scale)
	{
		_pointProvider = pointProvider;
		_scale = scale;
	}
	public bool TryGetPoint(out Vector2 point)
	{
		if (_pointProvider.TryGetPoint(out Vector2 startPoint))
		{
			point = startPoint * _scale;
			return true;
		}

		point = default;
		return false;
	}
}
