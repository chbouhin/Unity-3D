using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public string _theme = null;
    public string _regroupement = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManagerSingleton>().PlayMusic(_theme, _regroupement);
    }
}
