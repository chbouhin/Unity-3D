using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxEnd : MonoBehaviour
{
    [SerializeField] private SceneUpdate _sceneUpdate;
    [SerializeField] private Objective _obj;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<SaveToLeaderboard>() != null)
            gameObject.GetComponent<SaveToLeaderboard>().Save();
        if (_obj != null)
            _obj.FinishObj();
        _sceneUpdate.NextScene();
    }
}
