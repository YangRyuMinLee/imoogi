using System;
using UnityEngine;

public class TutorialGameManager : GameManager
{
    public bool stop = false;
    
    [Serializable]
    public struct CorporationData
    {
        public string name;
        public CorporationType type;
        public long initialPrice;
    }
    [Header("Tutorial"), SerializeField] private CorporationData corporationData; 
    
    void Awake()
    {
        game = new Game();
        game.shares.Add(new Corporation(corporationData.name, corporationData.type, corporationData.initialPrice), 0);
    }

    private void Start()
    {
        menuStack = GameObject.FindGameObjectWithTag("MenuStack").GetComponent<MenuStack>();
        Speed = 1f;
        Paused = false;
        statusBar.SetDate(game.time);
        game.eventTriggerer = eventTriggerer;
        
        OnTickEvent();
    }

    private new void Update()
    {
        if (stop) return;
        
        base.Update();
    }
}
