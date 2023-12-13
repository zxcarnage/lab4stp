using System;
using UnityEngine;

[RequireComponent(typeof(BulletMover))]
public class Bullet : MonoBehaviour
{
    private BulletMover _bulletMover;
    private float _bulletDamage;
    
    private void Awake()
    {
        _bulletMover = GetComponent<BulletMover>();
    }

    public void Spawn(Transform spawnPoint, float bulletDamage)
    {
        _bulletDamage = bulletDamage;
        transform.position = spawnPoint.position;
        _bulletMover.LaunchBullet();
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollision");
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TryDealDamage(_bulletDamage);
            gameObject.SetActive(false);
        }
            
    }
}
