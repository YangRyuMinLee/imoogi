using System;
using UnityEngine;

public class TutorialGameManager : GameManager
{
    void Awake()
    {
        game = new Game();
    }

    private void Start()
    {
        menuStack = GameObject.FindGameObjectWithTag("MenuStack").GetComponent<MenuStack>();
        Speed = 1f;
        Paused = false;
        statusBar.SetDate(game.time);
    }
}
