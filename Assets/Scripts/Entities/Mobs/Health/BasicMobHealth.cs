using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMobHealth : MobHealth
{
    [SerializeField] private BasicMobManager _basicMobManager;
    private bool _isRunning = false;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (!_isRunning && _health <= 50) {
            _basicMobManager.StartRunning();
            _isRunning = true;
        }
    }
}
