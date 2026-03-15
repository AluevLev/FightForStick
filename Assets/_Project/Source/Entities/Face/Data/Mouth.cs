using IceFebruary.Proxy;
using IceFebruary.Render;


public readonly struct Mouth
{
	public ISprite Value { get; init; }

	[GenerateScriptableObjectProxy]
	public Mouth(ISprite _mouth)
	{
		Value = _mouth;
	}
}
