using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _message;
    [SerializeField] private int _end;
    private int _value = 0;
    private bool _isFinish = false;

    public void UpdateObj(int value)
    {
        if (_isFinish)
            return;
        _value += value;
        if (_end > 1)
            _text.text = _message + " (" + _value.ToString() + " / " + _end.ToString() + ")";
        if (_value >= _end)
            FinishObj();
    }

    public void FailedObj()
    {
        _text.text = _message;
        _text.color = Color.red;
        _isFinish = true;
    }

    public void FinishObj()
    {
        _text.text = _message;
        _text.color = Color.green;
        _isFinish = true;
    }
}
