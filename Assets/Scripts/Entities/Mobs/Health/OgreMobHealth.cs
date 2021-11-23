using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreMobHealth : AMobHealth
{
    [SerializeField] private OgreMobManager _ogreMobManager;
    private bool _isInRage = false;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (!_isInRage && _health <= 100) {
            _ogreMobManager.StartRaging();
            _isInRage = true;
        }
    }

    protected override void AnimTakingDamage()
    {
        _animator.Play("Damage", -1, 0f);
    }

    protected override void AnimDying()
    {
        _animator.Play("Death");
    }
}
