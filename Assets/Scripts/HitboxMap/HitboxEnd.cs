using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxEnd : MonoBehaviour
{
    [SerializeField] private GameObject _victory;
    [SerializeField] private Objective _obj1;
    [SerializeField] private Timer _timer;
    [SerializeField] private Objective _obj2;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<SaveToLeaderboard>() != null)
            gameObject.GetComponent<SaveToLeaderboard>().Save();
        if (_obj1 != null && _timer.timer <= 120f)
            _obj1.FinishObj();
        if (_obj2 != null)
            _obj2.FinishObj();
        _victory.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
