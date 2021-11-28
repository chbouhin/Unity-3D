using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicUIHealthManager : AHealthManager
{
    [SerializeField] protected float _health = 100f;
    [SerializeField] protected Slider _healthBar;

    private void Start()
    {
        _healthBar.maxValue = _health;
        _healthBar.value = _health;
    }

    public override void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0)
            Die();
        _healthBar.value = _health;
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
