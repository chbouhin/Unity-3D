using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject _light;
    public float _batteryCapacity = 5f;
    public float _batteryReloadFactor = 4f;
    private float _batteryTimer;

    private void Awake()
    {
        _batteryTimer = _batteryCapacity;
    }

    // Start is called before the first frame update
    void Start()
    {
        _light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_batteryTimer != 0f && Input.GetKeyDown("f"))
            _light.SetActive(!_light.activeInHierarchy);
        if (_light.activeInHierarchy) {
            _batteryTimer -= Time.deltaTime;
            if (_batteryTimer <= 0f)
                _light.SetActive(false);
        } else if (_batteryTimer <= _batteryCapacity)
            _batteryTimer += Time.deltaTime / _batteryReloadFactor;
    }
}
