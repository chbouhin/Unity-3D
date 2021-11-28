using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    //public GameObject _light;
    [SerializeField] private float _batteryCapacity = 5f;
    [SerializeField] private float _batteryReloadFactor = 4f;
    [Range(0, 1)] [SerializeField] private float _minIntensity = 0.4f;
    [SerializeField] private Slider _batterySlider;
    private float _batteryTimer;
    private Flashlight_PRO _flashlightProManager;
    private bool _isActive = false;

    private void Awake()
    {
        _batteryTimer = _batteryCapacity;
        _flashlightProManager = gameObject.GetComponent<Flashlight_PRO>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_batteryTimer != 0f && Input.GetKeyDown("f")) {
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
        if (_batterySlider != null)
            _batterySlider.value = _batteryTimer / _batteryCapacity;
    }

    public void AddBattery(float percentToAdd)
    {
        _batteryTimer = Mathf.Clamp(_batteryTimer + (_batteryCapacity * percentToAdd), 0f, _batteryCapacity);
    }
}
