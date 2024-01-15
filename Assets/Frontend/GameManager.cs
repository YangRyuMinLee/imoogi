using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public Game game;
    public float interval = 1f;
    private float timer;
    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private TextMeshProUGUI assetText;

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
    }

    #endregion
    
    private void Start()
    {
        UpdateDateText();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= interval){
            timer -= interval;
            game.Tick();
            onTickEvent?.Invoke();
            UpdateDateText();
        }
        UpdateMoneyText();
    }


    private void UpdateDateText()
    {
        dateText.text = game.time.ToString();
    }

    private void UpdateMoneyText()
    {
        cashText.text = game.cash.ToString("#,##").Replace(',', ' ') + " 유동여의";
        assetText.text = game.Assets.ToString("#,##").Replace(',', ' ') + " 총여의";
    }
}
