using UnityEngine;
using System;

[Serializable]
public class UnityAnimatorNameField : IUnityAnimatorFieldName
{
	[SerializeField] private string _name;
	public AnimatorFieldName GetAnimatorFieldName() => new(_name);
}
