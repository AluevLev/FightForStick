using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] [Range(0f, 1f)] private float _interpotaion;
    private Func<Vector2> _targetPosition;
    private void Update()
    {
        //transform.position = 
    }
    private void CalculateRightPosition(Vector2 position) => Vector2.Lerp(transform.position, position, _interpotaion);
}
