using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIHealthManager : BasicUIHealthManager
{
    [SerializeField] protected GameObject _gameOverMenu;
    bool _isDead = false;

    protected override void Die()
    {
        if (!_isDead) {
            _isDead = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            _gameOverMenu.SetActive(true);
        }
    }
}
