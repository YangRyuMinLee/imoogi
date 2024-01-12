using System.Collections.Generic;
using UnityEngine;

public class MenuStack : MonoBehaviour
{
    public Stack<GameObject> menuStack;
    public GameObject initialStack;

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
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pop();
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
