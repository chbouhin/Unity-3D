using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicUIHealthManager : AHealthManager
{
    [SerializeField] private float _life = 100;
    [SerializeField] protected Slider _healthBar;

    private void Start()
    {
        _healthBar.maxValue = _life;
        _healthBar.value = _life;
    }

    public override void TakeDamage(float amount)
    {
        _life -= amount;
        if (_life <= 0)
            Die();
        _healthBar.value = _life;
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
