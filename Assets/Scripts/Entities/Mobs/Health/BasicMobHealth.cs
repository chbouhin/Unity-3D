using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMobHealth : AMobHealth
{
    [SerializeField] private BasicMobManager _basicMobManager;
    private bool _isRunning = false;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (!_isRunning && _health <= 50) {
            _basicMobManager.StartRunning();
            _isRunning = true;
        }
    }

    protected override void AnimTakingDamage()
    {
        _animator.Play("Damage0" + Random.Range(0, 2).ToString());
    }

    protected override void AnimDying()
    {
        _animator.Play("Dead0" + Random.Range(0, 2).ToString());
    }
}
