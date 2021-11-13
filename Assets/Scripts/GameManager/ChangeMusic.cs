using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    [SerializeField] private string _theme = null;
    [SerializeField] private string _regroupement = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManagerSingleton>().PlayMusic(_theme, _regroupement);
    }
}
