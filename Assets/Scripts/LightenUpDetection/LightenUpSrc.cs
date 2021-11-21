using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightenUpSrc : MonoBehaviour
{
    protected List<GameObject> _lightenUpList = new List<GameObject>();
    protected LightenUpDetector _detector = null;
    protected LayerMask _layerToDetect;

    private void Awake()
    {
        _detector = GameObject.Find("GameSceneManager").GetComponent<LightenUpDetector>();
        _layerToDetect = _detector._layerToDetect;
    }

    private void OnTriggerEnter(Collider other)
    {
        AddItem(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        RemoveItem(other.gameObject);
    }

    private void OnDisable()
    {
        RemoveAllLightenUpItem();
    }

    private void OnDestroy()
    {
        RemoveAllLightenUpItem();
    }

    protected void AddItem(GameObject item)
    {
        if (_layerToDetect == (_layerToDetect | 1 << item.layer) && !_lightenUpList.Contains(item)) {
            _lightenUpList.Add(item);
            _detector.Add(item);
        }
    }

    protected void RemoveItem(GameObject item)
    {
        if (_layerToDetect == (_layerToDetect | 1 << item.layer) && _lightenUpList.Contains(item)) {
            _lightenUpList.Remove(item);
            _detector.Remove(item);
        }
    }

    protected void RemoveAllLightenUpItem()
    {
        foreach (GameObject elem in _lightenUpList)
            _detector.Remove(elem);
        _lightenUpList.Clear();
    }
}
