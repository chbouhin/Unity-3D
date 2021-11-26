using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMobManager : AMobManager
{
    private bool _isRunning = false;

    protected override void IsMoving()
    {
        AnimMoving(true);
    }

    protected override void IsWaiting()
    {
        if (_AIPath.canMove)
            AnimIdleWait();
    }

    protected override void AnimIdleWait()
    {
        _animator.SetInteger("IsMoving", 1);
        _AIPath.maxSpeed = 1f;
        _isRunning = false;
    }

    protected override void AnimIdleAttack()
    {
    }

    protected override void AnimAttacking()
    {
        _animator.Play("Attack");
    }

    protected override void AnimMoving(bool move)
    {
        if (move) {
            _animator.SetInteger("IsMoving", 2);
            _AIPath.maxSpeed = 2.5f;
            _isRunning = true;
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
}
