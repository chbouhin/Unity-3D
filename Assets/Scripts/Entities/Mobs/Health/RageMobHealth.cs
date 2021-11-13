using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageMobHealth : AMobHealth
{
    [SerializeField] private RageMobManager _rageMobManager;
    private bool _isInRage = false;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (!_isInRage) {
            _rageMobManager.IsRaging();
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
