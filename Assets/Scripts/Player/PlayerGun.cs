using System;
using UnityEngine;

public class PlayerGun : ObjectPool
{
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _gunDamage;

    private float _timePassed;
    private void Start()
    {
        _timePassed = 0f;
        Initialize();
    }

    private void Update()
    {
        _timePassed += Time.deltaTime;
    }

    public void TryShoot()
    {
        if (_timePassed >= _shootDelay && TryGetElement(out GameObject poolObject))
        {
            poolObject.SetActive(true);
            Bullet bullet = poolObject.GetComponent<Bullet>();
            bullet.Spawn(_bulletSpawnPoint, _gunDamage);
            _timePassed = 0f;
        }
    }
}
