using System.Collections.Generic;
using UnityEngine;

public class MenuStack : MonoBehaviour
{
    public Stack<GameObject> menuStack;
    public GameObject initialStack;

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

    public void Push(GameObject menu)
    {
        if(menuStack.TryPeek(out GameObject top)){
            top.SetActive(false);
        }
        menuStack.Push(menu);
        menuStack.Peek().SetActive(true);
    }

    public void Pop()
    {
        if(menuStack.Count == 0){
            Debug.LogError("Nothing to pop in MenuStack!");
            return;
        }
        menuStack.Peek().SetActive(false);
        menuStack.Pop();
        if(menuStack.Count != 0){
            menuStack.Peek().SetActive(true);
        }
    }


}
