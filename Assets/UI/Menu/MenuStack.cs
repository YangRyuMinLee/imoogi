using System.Collections.Generic;
using UnityEngine;

public class MenuStack : MonoBehaviour
{
    public GameObject initialStack;
    public bool pausable;
    public GameObject pauseStack;

    private Stack<GameObject> menuStack;

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
        Peek().SetActive(true);
    }

    public void Pop()
    {
        if(Count == 0){
            Debug.LogError("Nothing to pop in MenuStack!");
            return;
        }
        Peek().SetActive(false);
        menuStack.Pop();
        if(Count != 0){
            Peek().SetActive(true);
        }
        if(pausable && Count == 0){
            Time.timeScale = 1f;
        }
    }

    public void PopUntil(GameObject element)
    {
        while (Count != 0 && element != Peek())
        {
            Pop();
        }
        if(Count != 0){
            Pop();
        }
    }
}
