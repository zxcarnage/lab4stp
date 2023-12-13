using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    
    private Rigidbody2D _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void LaunchBullet()
    {
        _rigidbody.velocity = Vector2.right * _bulletSpeed;
    }
}
