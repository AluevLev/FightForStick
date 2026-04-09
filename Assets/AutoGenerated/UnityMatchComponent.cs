// AUTO-GENERATED. DO NOT EDIT.
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityIceFebruary.Components;
public static class UnityMatchComponent
{
    public static readonly Dictionary<Type, Func<Component, IUnityAnalog>> FabricAliases = new()
	{
        { typeof(Animator), component => new UnityAnimator((Animator)component) },
        { typeof(Camera), component => new UnityCamera((Camera)component) },
        { typeof(Collider2D), component => new UnityCollider2D((Collider2D)component) },
        { typeof(HingeJoint2D), component => new UnityHingeJoint2D((HingeJoint2D)component) },
        { typeof(Rigidbody2D), component => new UnityRigidbody2D((Rigidbody2D)component) },
    };
    public static readonly Dictionary<Type, Type> UnityAnalogs = new()
	{
        { typeof(UnityAnimator), typeof(Animator) },
        { typeof(UnityCamera), typeof(Camera) },
        { typeof(UnityCollider2D), typeof(Collider2D) },
        { typeof(UnityHingeJoint2D), typeof(HingeJoint2D) },
        { typeof(UnityRigidbody2D), typeof(Rigidbody2D) },
    };
}
