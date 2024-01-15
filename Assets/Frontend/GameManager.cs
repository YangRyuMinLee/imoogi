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

    #region TEST (REMOVE LATER)

    [Serializable]
    public struct CorporationData
    {
        public string name;
        public CorporationType type;
        public int initialPrice;
    }
    private List<CorporationData> testCorporations;

    #endregion
    
    private void Start()
    {
        game = new Game();

        foreach (var corpData in testCorporations)
        {
            Corporation corporation = new(corpData.name, corpData.type, corpData.initialPrice);
            game.shares.Add(corporation, 0);
        }
        
        UpdateDateText();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= interval){
            timer -= interval;
            game.Tick();
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
