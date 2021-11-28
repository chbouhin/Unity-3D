using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGunShotObject : MonoBehaviour
{
    private float totalTime;
    void Start()
    {
        var sound = this.GetComponent<AudioSource>();
        totalTime = sound.clip.length;
    }

    void Update()
    {
        totalTime -= Time.deltaTime;
        if(totalTime <= 0f)
            Destroy(this.gameObject);
    }
}
