using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private float _batteryCapacity = 5f;
    [SerializeField] private float _batteryReloadFactor = 4f;
    [Range(0, 1)] [SerializeField] private float _minIntensity = 0.4f;
    [SerializeField] private Objective _obj;
    private float _batteryTimer;
    private Flashlight_PRO _flashlightProManager;
    private bool _isActive = false;

    private void Awake()
    {
        _batteryTimer = _batteryCapacity;
        _flashlightProManager = gameObject.GetComponent<Flashlight_PRO>();
    }

    void Update()
    {
        if (_batteryTimer != 0f && Input.GetKeyDown("f")) {
            if (_obj != null)
                _obj.FailedObj();
            _flashlightProManager.Switch();
            _isActive = !_isActive;
        }
        if (_isActive) {
            _batteryTimer -= Time.deltaTime;
            _flashlightProManager.Change_Intensivity((_minIntensity + ((_batteryTimer / _batteryCapacity) * (1 - _minIntensity))) * 100);
            if (_batteryTimer <= 0f) {
                _flashlightProManager.Switch();
                _isActive = false;
            }
        } else if (_batteryTimer <= _batteryCapacity)
            _batteryTimer += Time.deltaTime / _batteryReloadFactor;
    }

    public void AddBattery(float percentToAdd)
    {
        _batteryTimer = Mathf.Clamp(_batteryTimer + (_batteryCapacity * percentToAdd), 0f, _batteryCapacity);
    }
}
