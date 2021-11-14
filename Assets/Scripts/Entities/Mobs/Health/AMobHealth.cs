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
    GameObject TEST;//TEMPORAIRE

    private void Start()
    {
        _healthBar.maxValue = _health;
        _healthBar.value = _health;
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
        if (_AMobManager.enabled) {
            AnimDying();
            _AMobManager._AIPath.canMove = false;
            _AMobManager.enabled = false;
            Destroy(gameObject, 5f);
        }
    }

    protected abstract void AnimTakingDamage();

    protected abstract void AnimDying();
}
