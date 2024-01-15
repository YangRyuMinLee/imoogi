using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Game game;
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
    [SerializeField] private GameObject eventStack;
    [SerializeField] private StatusBar statusBar;

    private MenuStack menuStack;

    private void Start()
    {
        // for test
        // ^ for test??? why are we testing? this isn't aperture!
        game = new Game();
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
            statusBar.SetDate(game.time);
            if (game.remainingEvents.TryDequeue(out Event e))
            {
                menuStack.Push(eventStack);
            }
        }
        statusBar.SetCash(game.cash);
        statusBar.SetCash(game.Assets);
    }


}
