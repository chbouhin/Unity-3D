using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreMobManager : AMobManager
{
    private bool _isRunning = false;

    protected override void AnimIdleWait()
    {
    }

    protected override void AnimIdleAttack()
    {
    }

    protected override void AnimAttacking()
    {
        _animator.Play("Attack" + Random.Range(1, 3).ToString());
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
        return "Idle";
    }

    protected override string GetMoveName()
    {
        if (_isRunning)
            return "Run";
        else
            return "Walk";
    }

    public void StartRaging()
    {
        _isRunning = true;
        _AIPath.maxSpeed = 2.5f;
    }
}
