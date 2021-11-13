using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageMobHealth : AMobHealth
{
    [SerializeField] private WalkerMobManager _basicMobManager;
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
        _animator.Play("Damage", -1, 0f);
    }

    protected override void AnimDying()
    {
        _animator.Play("Death");
    }
}
