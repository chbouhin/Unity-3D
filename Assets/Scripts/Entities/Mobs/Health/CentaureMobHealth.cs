using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentaureMobHealth : AMobHealth
{
    [SerializeField] private CentaureMobManager _centaureMobManager;
    private bool _isInRage = false;
    private bool _secondLife = false;

    protected override void Die()
    {
        if (_isInRage) {
            if (_secondLife)
                base.Die();
        } else {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            AnimDying();
            _centaureMobManager.StartRaging();
            _isInRage = true;
            StartCoroutine(SecondLife(7.25f));
        }
    }

    IEnumerator SecondLife(float secs)
    {
        yield return new WaitForSeconds(secs);
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        _health = 120;
        _healthBar.value = _health;
        _secondLife = true;
    }

    protected override void AnimTakingDamage()
    {
        _animator.Play("Damage" + Random.Range(1, 3).ToString(), -1, 0f);
    }

    protected override void AnimDying()
    {
        if (_isInRage)
            _animator.Play("Death2");
        else
            _animator.Play("Death1");
    }
}
