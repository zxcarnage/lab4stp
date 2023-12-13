
using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MainCamera : MonoBehaviour
{
    private Player _player;
    
    private float _offsetX;
    private void Awake()
    {
        ServiceLocator.MainCamera = GetComponent<Camera>();
    }

    private void Start()
    {
        _player = ServiceLocator.Player;
        CalculateOffset();
    }

    private void CalculateOffset()
    {
        _offsetX = transform.position.x - _player.transform.position.x;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = new Vector3(_player.transform.position.x + _offsetX,transform.position.y, transform.position.z);
    }
}