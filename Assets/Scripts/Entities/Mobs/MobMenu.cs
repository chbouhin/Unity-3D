using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMenu : MonoBehaviour
{
    [SerializeField] protected Animator _animator;

    private void Start()
    {
        _animator.SetInteger("IsIdling", 1);
    }
}
