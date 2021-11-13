using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AMobHealth : MonoBehaviour
{
    [SerializeField] protected float _health = 100f;
    [SerializeField] protected Animator _animator;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private AMobManager _AMobManager;

    private void Start()
    {
        _healthBar.maxValue = _health;
        _healthBar.value = _health;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
            TakeDamage(20);
    }

    public virtual void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0)
            Die();
        else
            AnimTakingDamage();
        _healthBar.value = _health;
    }

    private void Die()
    {
        AnimDying();
        _AMobManager._AIPath.canMove = false;
        _AMobManager.enabled = false;
        Destroy(gameObject, 5f);
    }

    protected abstract void AnimTakingDamage();

    protected abstract void AnimDying();
}
