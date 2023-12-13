using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour, IDamagable, IDieable
{
    [SerializeField] private float _hp;

    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void Spawn(Vector3 spawnPoint)
    {
        transform.position = spawnPoint;
        _enemyMover.Launch();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void TryDealDamage(float damage)
    {
        if (damage > 0)
            DealDamage(damage);
    }

    private void DealDamage(float damage)
    {
        if (_hp < damage)
            Die();
        _hp -= damage;
        if (_hp <= 0)
            Die();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.TryGetComponent(out DeadZone deadZone))
            Die();
    }
}