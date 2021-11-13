using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMobManager : AMobManager
{
    private bool _isRunning;

    protected override void AnimIdleWait()
    {
        _animator.SetInteger("IsIdling", 2);
    }

    protected override void AnimIdleAttack()
    {
        _animator.SetInteger("IsIdling", 1);
    }

    protected override void AnimAttacking()
    {
        _animator.Play("Attack0" + Random.Range(0, 3).ToString());
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

    public void StartRunning()
    {
        _isRunning = true;
        _AIPath.maxSpeed = 2f;
    }
}
