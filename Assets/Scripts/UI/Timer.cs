using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private Objective _obj;
    [SerializeField] private Text _textTimer;
    [HideInInspector] public float timer = 0f;

    private void Start()
    {
        _textTimer.text = "Timer : " + timer;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        _textTimer.text = "Timer : " + FormatTime(timer);
        if (timer > 120f && _obj != null)
            _obj.FailedObj();
    }

    private string FormatTime(float time)
    {
        int minutes = (int) time / 60;
        int seconds = (int) Math.Ceiling(time - 60 * minutes);
        return string.Format("{0:00}.{1:00}", minutes, seconds);
    }
}
