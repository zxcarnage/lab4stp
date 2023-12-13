using System;
using UnityEngine;

public class Player : MonoBehaviour, IDieable
{
    private void Awake()
    {
        ServiceLocator.Player = this;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
            Die();
    }

    public void Die()
    {
        ServiceLocator.MainUI.ShowLoseScreen();
    }
}