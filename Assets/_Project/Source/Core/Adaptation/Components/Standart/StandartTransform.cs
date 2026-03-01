using UnityEngine;

public class StandartTransform : ITogglable, ITransform
{
	private readonly Transform _transform;
    public bool Enabled { get; set; } = true;
    public StandartTransform(Transform transform)
    {
        _transform = transform;
    }
    public Vector2 Position { get; set; }
    public Vector2 TransformDirection(Vector2 vector2) => _transform.TransformDirection(vector2);
}
