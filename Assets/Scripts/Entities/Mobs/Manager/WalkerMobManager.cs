using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerMobManager : AMobManager
{
    private bool _isRunning;

    protected override void AnimIdleWait()
    {
        _animator.SetInteger("IsIdling", 1);
    }

    protected override void AnimIdleAttack()
    {
        _animator.SetInteger("IsIdling", 2);
    }

    protected override void AnimAttacking()
    {
        _animator.Play("Attack" + Random.Range(1, 4).ToString());
    }

    protected override void AnimMoving(bool move)
    {
        if (move) {
            if (_isRunning)
                _animator.SetInteger("IsMoving", 2);
            else
                _animator.SetInteger("IsMoving", 1);
        } else
            _animator.SetInteger("IsMoving", 0);
    }

    protected override string GetIdleAttackName()
    {
        return "Idle2";
    }

    protected override string GetMoveName()
    {
        if (_isRunning)
            return "Run";
        else
            return "Walk";
    }

    public void StartRunning()
    {
        _isRunning = true;
        _AIPath.maxSpeed = 2f;
    }
}
