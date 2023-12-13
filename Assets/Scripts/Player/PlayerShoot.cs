using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerGun _playerGun;
    
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.ShootButtonClicked += OnShootButtonClicked;
    }

    private void OnDisable()
    {
        _playerInput.ShootButtonClicked -= OnShootButtonClicked;
    }

    private void OnShootButtonClicked()
    {
        _playerGun.TryShoot();
    }
}
