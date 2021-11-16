using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ALootable : MonoBehaviour
{
    public string _objectType = "unknown";

    public virtual void OnLoot(GameObject looter)
    {
        if (looter.tag == "Player") {
            looter.GetComponentInChildren<PlayerInventory>().Add(_objectType);
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        OnLoot(other.gameObject);
    }
}
