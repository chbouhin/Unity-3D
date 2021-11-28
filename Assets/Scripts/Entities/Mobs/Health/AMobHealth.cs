using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AMobHealth : AHealthManager
{
    [SerializeField] protected float _health = 100f;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Slider _healthBar;
    [SerializeField] private int _giveScore = 100;
    [SerializeField] private bool _isBoss = false;
    [SerializeField] private AudioSource _takeDmgSFX;
    
    private Score _score;
    private Objective _obj1;
    private Objective _obj2;
    protected bool _isDead = false;

    private void Start()
    {
        _healthBar.maxValue = _health;
        _healthBar.value = _health;
        _score = GameObject.Find("GameSceneManager").GetComponent<Score>();
        GameObject obj11 = GameObject.Find("Obj11");
        if (obj11 != null)
            _obj1 = obj11.GetComponent<Objective>();
        if (_isBoss) {
            GameObject obj12 = GameObject.Find("Obj12");
            if (obj12 != null)
                _obj2 = obj12.GetComponent<Objective>();
        }
    }

    public override void TakeDamage(float amount)
    {
        if (_health > 0) {
            _health -= amount;
            if (_health <= 0)
                Die();
            else {
                AudioSource takeDmgSFX = Instantiate(_takeDmgSFX, this.transform.position, this.transform.rotation);
                AnimTakingDamage();
            }
            _healthBar.value = _health;
        }
    }

    protected override void Die()
    {
        if (!_isDead) {
            AnimDying();
            Destroy(gameObject, 5f);
            _isDead = true;
            _score.AddScore(_giveScore);
            if (_obj1 != null)
                _obj1.UpdateObj(1);
            if (_obj2 != null)
                _obj2.UpdateObj(1);
        }
    }

    protected abstract void AnimTakingDamage();

    protected abstract void AnimDying();
}
