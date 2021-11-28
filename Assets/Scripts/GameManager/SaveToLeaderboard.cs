using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveToLeaderboard : MonoBehaviour
{
    public void Save()
    {
        if (GameObject.Find("GameManager") != null) {
            GameManagerSingleton gameManager = GameObject.Find("GameManager").GetComponent<GameManagerSingleton>();
            if (gameManager != null) {
                gameManager.StopTimer();
                gameManager.SaveScore();
                gameManager.ResetScore();
                gameManager.ResetTimer();
            }
        }
    }
}
