using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _verticalMovingSpeed;
    [SerializeField] private float _horizontalMovingSpeed;
    
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var rightMovementVector = Vector3.right * _horizontalMovingSpeed * Time.deltaTime;
        transform.position += _playerInput.MovingDirection * _verticalMovingSpeed + rightMovementVector ;
    }
}
