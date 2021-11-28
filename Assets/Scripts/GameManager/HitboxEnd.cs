using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxEnd : MonoBehaviour
{
    [SerializeField] private SceneUpdate _sceneUpdate;

    private void OnTriggerEnter(Collider other)
    {
        _sceneUpdate.NextScene();
    }
}
