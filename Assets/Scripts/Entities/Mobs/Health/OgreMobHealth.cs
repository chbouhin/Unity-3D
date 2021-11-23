using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreMobHealth : AMobHealth
{
    protected override void AnimTakingDamage()
    {
        _animator.Play("Damage", -1, 0f);
    }

    protected override void AnimDying()
    {
        _animator.Play("Death");
    }
}
