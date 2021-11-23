using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerMobHealth : AMobHealth
{
    [SerializeField] private WalkerMobManager _basicMobManager;
    private bool _isInRage = false;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (!_isInRage && _health <= 30) {
            _basicMobManager.StartRaging();
            _isInRage = true;
        }
    }

    protected override void AnimTakingDamage()
    {
        _animator.Play("Damage" + Random.Range(1, 3).ToString(), -1, 0f);
    }

    protected override void AnimDying()
    {
        _animator.Play("Death" + Random.Range(1, 3).ToString());
    }
}
