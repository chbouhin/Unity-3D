using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHealthManager : AHealthManager
{
    public float _health = 50f;
    
    public override void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0f)
            Die();
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
