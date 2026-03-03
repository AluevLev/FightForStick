using UnityEngine;
using February.Proxy;

public class AnimatorFieldName
{
    private readonly int _hash;
	[GenerateProxy]
    public AnimatorFieldName(string name)
	{
		_hash = Animator.StringToHash(name);
	}
	public AnimatorFieldName(int hash)
	{
		_hash = hash;
	}
	public int Hash => _hash;
}
