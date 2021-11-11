using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATarget : MonoBehaviour
{
    public abstract void TakeDamage(float amount);
    protected abstract void Die();
}
