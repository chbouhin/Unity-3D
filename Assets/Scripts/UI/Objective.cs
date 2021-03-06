using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _explosions;
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
            _text.text = _message + " (" + _value.ToString() + "/" + _end.ToString() + ")";
        if (_value >= _end)
            FinishObj();
    }

    public void FailedObj()
    {
        if (_isFinish)
            return;
        _text.text = _message;
        _text.color = Color.red;
        _isFinish = true;
    }

    public void FinishObj()
    {
        if (_isFinish)
            return;
        _text.text = _message;
        _text.color = Color.green;
        _isFinish = true;
        Instantiate(_explosions[Random.Range(0, _explosions.Count)], transform.position, Quaternion.identity);
    }
}
