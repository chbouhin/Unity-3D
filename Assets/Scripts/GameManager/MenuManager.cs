using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameManager") != null) {
            GameManagerSingleton gameManager = GameObject.Find("GameManager").GetComponent<GameManagerSingleton>();
            if (gameManager != null) {
                gameManager.ResetScore();
                gameManager.ResetTimer();
            }
        }
    }
}
