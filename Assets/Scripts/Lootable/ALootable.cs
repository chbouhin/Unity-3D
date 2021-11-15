using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ALootable : MonoBehaviour
{
    public virtual void OnLoot(GameObject looter)
    {
        if (looter.tag == "Player")
            looter.GetComponentInChildren<PlayerInventory>().Add(gameObject.name);
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        OnLoot(other.gameObject);
    }
}
