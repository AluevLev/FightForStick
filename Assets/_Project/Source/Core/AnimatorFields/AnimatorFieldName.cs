using UnityEngine;

public class AnimatorFieldName
{
    private readonly int _hash;
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
