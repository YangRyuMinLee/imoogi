using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class BarManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI listenText;
    [SerializeField] private List<string> listenList;
    private float time = 0f;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void Show(float duration = 1f)
    {
        //random get
        int randomNumber = new Random().Next(0, listenList.Count);
        listenText.text = listenList[randomNumber];
        
        if(gameManager.game.cash >= 50000)
            gameManager.game.cash -= 50000;

        time = duration;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            listenText.text = string.Empty;
        }
    }
}
