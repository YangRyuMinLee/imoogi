using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingChanger : MonoBehaviour
{
    private GameManagerBase gameManager;
    
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManagerBase>();
        gameManager.onTickEvent += Tick;
    }

    public void Tick()
    {
        if (!gameManager) return;

        if (gameManager.GetGame().Assets <= 0)
        {
            SceneManager.LoadScene("DieScene");
        }
        else if (gameManager.GetGame().Assets >= 100000000)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
