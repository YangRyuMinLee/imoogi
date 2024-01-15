using System.Collections.Generic;
using UnityEngine;

public class MenuStack : MonoBehaviour
{
    public GameObject initialStack;
    public bool pausable;
    public bool retainInitial;
    public GameObject pauseStack;
    public GameObject background;

    private Stack<GameObject> menuStack;

    private Stack<GameObject> _menuStack;


    public int Count => menuStack.Count;

    void Awake()
    {
        menuStack = new Stack<GameObject>();
    }

    void Start()
    {
        if (initialStack != null)
        {
            Push(initialStack);
        }
        if(pausable)
        {
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Count == 0)
            {
                if (pausable)
                {
                    Push(pauseStack);
                    Time.timeScale = 0f;
                }
            }
            else
            {
                Pop();
            }
        }
    }

    public GameObject Peek() => menuStack.Peek();

    public void Push(GameObject menu)
    {
        if(menuStack.TryPeek(out GameObject top)){
            top.SetActive(false);
        }
        menuStack.Push(menu);
        UpdateGameObjects();
    }

    public void Pop()
    {
        if(Count == 1 && retainInitial){
            return;
        }
        if(Count == 0){
            Debug.LogError("Nothing to pop in MenuStack!");
            return;
        }
        Peek().SetActive(false);
        menuStack.Pop();

        UpdateGameObjects();
    }

    private void UpdateGameObjects()
    {
        if(background != null){
            background.SetActive(Count != 0);
        }
        if(Count != 0){
            Peek().SetActive(true);
        }

        if(pausable){
            Time.timeScale = Count == 0 ? 1f : 0f;
        }
    }
}
