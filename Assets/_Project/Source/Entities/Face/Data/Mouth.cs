using IceFebruary.Proxy;
using IceFebruary.Render;


public readonly struct Mouth
{
	public ISprite Value { get; private init; }

	[ScriptableObjectProxy]
	public Mouth(ISprite mouth)
	{
		Value = mouth;
	}
}
