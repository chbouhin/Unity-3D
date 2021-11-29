using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMobHealth : AMobHealth
{
    private int nbLife = 3;

    protected override void Die()
    {
        nbLife--;
        if (nbLife == 0) {
            base.Die();
        } else {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            _animator.Play("Fall");
            StartCoroutine(NewLife(7.75f));
        }
    }

    IEnumerator NewLife(float secs)
    {
        yield return new WaitForSeconds(secs);
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        _health = 1f;
        _healthBar.value = _health;
    }

    protected override void AnimTakingDamage()
    {
    }

    protected override void AnimDying()
    {
        _animator.Play("Death");
    }
}
