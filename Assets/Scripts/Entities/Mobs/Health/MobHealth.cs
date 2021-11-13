using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobHealth : MonoBehaviour
{
    [SerializeField] protected float _health = 100f;
    [SerializeField] private Slider _healthBar;

    private void Start()
    {
        _healthBar.maxValue = _health;
        _healthBar.value = _health;
    }

    public virtual void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0)
            Die();
        _healthBar.value = _health;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
