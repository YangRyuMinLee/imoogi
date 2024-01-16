using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    [HideInInspector] public Game game;
    private float Timer{
        get => timer;
        set {
            timer = value;
            statusBar.SetTimerFill(game.time, timer);
        }
    }
    private float Speed{
        get => speed;
        set {
            speed = value;
            statusBar.SetSpeed(paused, speed);
        }
    }

    private float timer;
    private float speed;
    private bool Paused{
        get => paused;
        set {
            paused = value;
            statusBar.SetSpeed(paused, speed);
        }
    }
    private bool paused;
    [SerializeField] private EventDisplay eventDisplay;
    [SerializeField] private StatusBar statusBar;

    private MenuStack menuStack;

    public delegate void TickEventHandler();
    public TickEventHandler onTickEvent;

    #region TEST (REMOVE LATER)

    [Serializable]
    public struct CorporationData
    {
        public string name;
        public CorporationType type;
        public int initialPrice;
    }
    public List<CorporationData> testCorporations;

    private void Awake()
    {
        game = new Game();

        foreach (var corpData in testCorporations)
        {
            Corporation corporation = new(corpData.name, corpData.type, corpData.initialPrice);
            game.shares.Add(corporation, 0);
        }
        game.TriggerEvent(testEvent);
    }

    public Event testEvent;

    #endregion

    private void Start()
    {
        // for test
        // ^ for test??? why are we testing? this isn't aperture
        menuStack = GameObject.FindGameObjectWithTag("MenuStack").GetComponent<MenuStack>();
        Speed = 1f;
        Paused = false;
        statusBar.SetDate(game.time);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            Paused = !Paused;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Speed = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Speed = 2f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Speed = 3f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Speed = 4f;
        }

        if (!paused)
        {
            Timer += Time.deltaTime * Speed;
        }

        if(Timer >= 1f){
            Timer -= 1f;
            game.Tick();
            onTickEvent?.Invoke();
            statusBar.SetDate(game.time);
            if (game.remainingEvents.TryDequeue(out Event e))
            {
                menuStack.Push(eventDisplay.gameObject);
                eventDisplay.SetEvent(e);
            }
        }
        statusBar.SetCash(game.cash);
        statusBar.SetAsset(game.Assets);
    }


}
