using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MobManager : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private AIPath _AIPath;
    [SerializeField] private Animator _animator;
    private bool _isAttacking = false;
    private float _cooldown = 5f;

    private void Start()
    {
        _animator.SetInteger("IsIdling", 2);
    }

    private void Update()
    {
        if (_isAttacking) {
            _animator.SetInteger("IsAttacking", 0);
        } else if (Vector3.Distance(transform.position, _target.transform.position) < _AIPath.endReachedDistance)
            IsAttacking();
    }

    private void IsAttacking()
    {
        _isAttacking = true;
        _AIPath.canMove = false;
        _animator.SetInteger("IsAttacking", Random.Range(1, 4));
        _animator.SetInteger("IsIdling", 1);
        StartCoroutine(StopAttacking(_cooldown));
    }

    IEnumerator StopAttacking(float time)
    {
        yield return new WaitForSeconds(time);
        _isAttacking = false;
        _AIPath.canMove = true;
    }
}
