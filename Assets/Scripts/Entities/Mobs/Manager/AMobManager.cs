using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class AMobManager : MonoBehaviour
{
    [SerializeField] protected AIPath _AIPath;
    [SerializeField] private AIDestinationSetter _AIDestinationSetter;
    [SerializeField] protected Animator _animator;
    private GameObject _target;
    [SerializeField] protected float _cooldown = 3f;
    protected float _cooldownTimer;
    [SerializeField] protected float _rangeDetect = 5f;
    [SerializeField] protected float _rangeAttack = 2f;
    [SerializeField] protected int _damage = 10;

    protected void Start()
    {
        _target = GameObject.Find("Player");
        _AIDestinationSetter.target = _target.transform;
        AnimIdleWait();
        _cooldownTimer = _cooldown;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _target.transform.position);
        if (distance <= _rangeDetect) {
            if (distance > _rangeAttack)
                IsMoving();
            else
                IsAttacking();
        } else {
            IsWaiting();
        }
        Rotation();
    }

    private void Rotation()
    {
        Vector3 dir = _target.transform.position - transform.position;
        dir.y = transform.position.y;
        dir.Normalize();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }

    private void IsMoving()
    {
        if (!_AIPath.canMove) {
            AnimMoving(true);
            _AIPath.canMove = true;
        }
    }

    private void IsAttacking()
    {
        if (_AIPath.canMove) {
            _AIPath.canMove = false;
            AnimIdleAttack();
            AnimMoving(false);
        }
        if (_cooldownTimer >= _cooldown) {
            //Infliger les dommages ici
            AnimAttacking();
            _cooldownTimer -= _cooldown;
        } else {
            _cooldownTimer += Time.deltaTime;
        }
    }

    private void IsWaiting()
    {
        if (_AIPath.canMove) {
            AnimIdleWait();
            AnimMoving(false);
            _AIPath.canMove = false;
        }
    }

    protected abstract void AnimIdleWait();

    protected abstract void AnimIdleAttack();

    protected abstract void AnimAttacking();

    protected abstract void AnimMoving(bool move);
}
