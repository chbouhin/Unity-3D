using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableBattery : ALootable
{
    [Range(0, 1)] [SerializeField] private float _batteryCapacity = 0.1f;
    private Objective _obj;

    private void Start()
    {
        GameObject obj21 = GameObject.Find("Obj21");
        if (obj21 != null)
            _obj = obj21.GetComponent<Objective>();
    }

    public override void OnLoot(GameObject looter)
    {
        if (looter.tag == "Player") {
            if (_obj != null)
                _obj.UpdateObj(1);
            looter.GetComponentInChildren<Flashlight>().AddBattery(_batteryCapacity);
            Destroy(gameObject);
        }
    }
}
