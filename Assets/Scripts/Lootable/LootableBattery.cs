using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableBattery : ALootable
{
    [Range(0, 1)] [SerializeField] private float _batteryCapacity = 0.1f;

    public override void OnLoot(GameObject looter)
    {
        Debug.Log("Enter OnLoot");
        if (looter.tag == "Player")
            looter.GetComponentInChildren<Flashlight>().AddBattery(_batteryCapacity);
        Destroy(gameObject);
    }
}
