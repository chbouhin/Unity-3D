using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (_pauseUI.activeSelf) {
                ContinueButton();
            } else if (Time.timeScale == 1) {
                _pauseUI.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void ContinueButton()
    {
        _pauseUI.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
