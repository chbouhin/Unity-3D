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
    private Score _score;
    protected bool _isDead = false;
    GameObject TEST;//TEMPORAIRE

    private void Start()
    {
        _healthBar.maxValue = _health;
        _healthBar.value = _health;
        _score = GameObject.Find("GameManager").GetComponent<Score>();
        TEST = GameObject.Find("Player");//TEMPORAIRE
    }

    private void Update()// TEMPORAIRE
    {
        if (Input.GetKeyDown("space"))
            TakeDamage(20);
        if (Input.GetKey(KeyCode.Q))
            TEST.transform.Translate(-Vector3.right * Time.deltaTime * 3);
        if (Input.GetKey(KeyCode.D))
            TEST.transform.Translate(Vector3.right * Time.deltaTime * 3);
        if (Input.GetKey(KeyCode.Z))
            TEST.transform.Translate(Vector3.forward * Time.deltaTime * 3);
        if (Input.GetKey(KeyCode.S))
            TEST.transform.Translate(-Vector3.forward * Time.deltaTime * 3);
    }

    public override void TakeDamage(float amount)
    {
        if (_health > 0) {
            _health -= amount;
            if (_health <= 0)
                Die();
            else
                AnimTakingDamage();
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
        }
    }

    protected abstract void AnimTakingDamage();

    protected abstract void AnimDying();
}
