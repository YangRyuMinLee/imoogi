using UnityEngine;
using System.IO;
using System.Text;

public class GameManager : GameManagerBase
{

    [HideInInspector] public Game game;
    private float Timer
    {
        get => timer;
        set
        {
            timer = value;
            statusBar.SetTimerFill(game.time, timer);
        }
    }
    private float Speed
    {
        get => speed;
        set
        {
            speed = value;
            statusBar.SetSpeed(paused, speed);
        }
    }

    private float timer;
    private float speed;
    private bool Paused
    {
        get => paused;
        set
        {
            paused = value;
            statusBar.SetSpeed(paused, speed);
        }
    }
    private bool paused;
    [SerializeField] private EventDisplay eventDisplay;
    [SerializeField] private StatusBar statusBar;

    private MenuStack menuStack;

    private string path;

    public TextAsset newGameJson;
    public EventTriggerer eventTriggerer;

    private void Start()
    {
        path = Application.persistentDataPath + "/imoogi.json";
        if(SceneTransitionDataStorage.data.newGame)
        {
            LoadNew();
        }
        else
        {
            LoadFile();
        }
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
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Speed = 100f;
        }

        if (!paused)
        {
            Timer += Time.deltaTime * Speed;
        }

        if (Timer >= 1f)
        {
            Timer -= 1f;
            game.Tick();
            statusBar.SetDate(game.time);
            if (game.remainingEvents.Count != 0)
            {
                Event e = game.remainingEvents[0];
                game.remainingEvents.RemoveAt(0);
                menuStack.Push(eventDisplay.gameObject);
                eventDisplay.SetEvent(e);
            }
            onTickEvent?.Invoke();
        }
        statusBar.SetCash(game.cash);
        statusBar.SetAsset(game.Assets);
    }

    public void SaveFile()
    {
        string json = JsonUtility.ToJson(game);
        if(File.Exists(path)){
            File.Delete(path);
        }
        FileStream stream = File.Create(path);
        byte[] data = new UTF8Encoding(true).GetBytes(json);
        stream.Write(data, 0, data.Length);
        Debug.Log("Successfully saved to " + path);
    }

    public void LoadFile()
    {
        string json = File.ReadAllText(path);
        LoadJson(json);
        Debug.Log("Successfully loaded from " + path);
    }

    public void LoadNew(){
        LoadJson(newGameJson.text);
        Debug.Log("Successfully loaded new game");
    }

    public void LoadJson(string json){
        game = JsonUtility.FromJson<Game>(json);
        game.eventTriggerer = eventTriggerer;
    }

    public override Game GetGame() => game;
    public override event TickEventHandler onTickEvent;
}
