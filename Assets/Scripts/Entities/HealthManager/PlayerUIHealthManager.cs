using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIHealthManager : BasicUIHealthManager
{
    [SerializeField] protected GameObject _gameOverMenu;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (_health <= 0) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            _gameOverMenu.SetActive(true);
        }
    }
}
