using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class AMobManager : MonoBehaviour
{
    public AIPath _AIPath;
    [SerializeField] private AIDestinationSetter _AIDestinationSetter;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected float _cooldown = 3f;
    [SerializeField] protected float _rangeDetect = 10f;
    [SerializeField] protected float _rangeAttack = 2.5f;
    [SerializeField] protected int _damage = 10;
    protected float _cooldownTimer;
    private GameObject _target;

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
        AnimatorStateInfo animation = _animator.GetCurrentAnimatorStateInfo(0);
        if (distance <= _rangeDetect) {
            if (distance > _rangeAttack)
                IsMoving();
            else
                IsAttacking(animation);
        } else {
            IsWaiting();
        }
        if (_cooldownTimer < _cooldown)
            _cooldownTimer += Time.deltaTime;
        _AIPath.canMove = animation.IsName(GetMoveName());
    }

    private void Rotation()
    {
        Vector3 dir = _target.transform.position - transform.position;
        dir.y = transform.position.y;
        dir.Normalize();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
    }

    protected virtual void IsMoving()
    {
        if (!_AIPath.canMove)
            AnimMoving(true);
    }

    private void IsAttacking(AnimatorStateInfo animation)
    {
        if (animation.IsName(GetIdleAttackName()))
            Rotation();
        if (_AIPath.canMove) {
            AnimIdleAttack();
            AnimMoving(false);
        }
        if (_cooldownTimer >= _cooldown) {
            if (animation.IsName(GetIdleAttackName()) || animation.IsName(GetMoveName())) {
                //Infliger les dommages ici
                AnimAttacking();
                _cooldownTimer -= _cooldown;
            }
        }
    }

    protected virtual void IsWaiting()
    {
        if (_AIPath.canMove) {
            AnimIdleWait();
            AnimMoving(false);
        }
    }

    protected abstract void AnimIdleWait();

    protected abstract void AnimIdleAttack();

    protected abstract void AnimAttacking();

    protected abstract void AnimMoving(bool move);

    protected abstract string GetIdleAttackName();

    protected abstract string GetMoveName();
}
