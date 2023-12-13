using System;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.TryGetComponent(out Bullet bullet))
            bullet.gameObject.SetActive(false);
    }
}