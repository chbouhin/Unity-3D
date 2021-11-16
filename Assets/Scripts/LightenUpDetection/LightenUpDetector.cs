using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightenUpDetector : MonoBehaviour
{
    public LayerMask _layerToDetect;
    private Dictionary<GameObject, int> _objectList = new Dictionary<GameObject, int>();

    public void Add(GameObject LightenUpItem)
    {
        if (_layerToDetect == (_layerToDetect | 1 << LightenUpItem.layer)) {
            if (_objectList.ContainsKey(LightenUpItem))
                _objectList[LightenUpItem]++;
            else
                _objectList.Add(LightenUpItem, 1);
        }
    }

    public void Remove(GameObject LightenUpItem)
    {
        if (_layerToDetect == (_layerToDetect | 1 << LightenUpItem.layer))
            if (_objectList.ContainsKey(LightenUpItem)) {
                _objectList[LightenUpItem]--;
                if (_objectList[LightenUpItem] <= 0)
                    _objectList.Remove(LightenUpItem);
            }
    }

    public bool IsLightenUp(GameObject LightenUpItem)
    {
        return _objectList.ContainsKey(LightenUpItem);
    }
}
