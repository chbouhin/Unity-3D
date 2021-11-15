using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public void SetVolume(float newVolume)
    {
        Debug.Log("New volume : " + (newVolume * 100));
    }
}
