using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MainChartManager : MonoBehaviour
{
    public Corporation currentCorporation;
    
    [SerializeField] private ChartDrawer chart;
    [SerializeField] private VerticalPriceIndicatorManager verticalPriceIndicator;
    [SerializeField] private TextMeshProUGUI currentPriceText;
    [SerializeField] private TextMeshProUGUI chartNameText;
    private GameManager gameManager;
    
    public enum FilterMode
    {
        All,
        R20,
    }
    private FilterMode filterMode;

    private GameManager GetGameManager() => GameObject.FindObjectsOfType<GameManager>()[0];

    private void Start()
    {
        gameManager = GetGameManager();
        currentCorporation = gameManager.game.Corporations.ToList()[0];
        
        gameManager.onTickEvent += Tick;
    }

    public void Tick()
    {
        List<int> priceHistory = currentCorporation.priceHistory;

        if (priceHistory.Count == 0)
        {
            priceHistory = new List<int>();
            priceHistory.Add(0);
        }

        switch (filterMode)
        {
            case FilterMode.R20:
                priceHistory = priceHistory.Skip(priceHistory.Count - 120).ToList();
                break;
        }
        
        chart.DrawChart(priceHistory, currentCorporation.ParValue);
        verticalPriceIndicator.UpdateIndicator(priceHistory);
        currentPriceText.text = currentCorporation.ParValue.ToString("#,##").Replace(',', ' ') + " 여의";
        chartNameText.text = currentCorporation.Name;
    }

    public void SetFilterMode(string mode)
    {
        switch (mode)
        {
            case "All":
                filterMode = FilterMode.All;
                break;
            case "R20":
                filterMode = FilterMode.R20;
                break;
        }
        Tick();
    }

    public void Buy(int amount)
    {
        gameManager ??= GetGameManager();

        int price = currentCorporation.ParValue * amount;

        if (gameManager.game.cash < price) return;
        
        gameManager.game.cash -= price;
        gameManager.game.shares[currentCorporation] += amount;
    }

    public void Sell(int amount)
    {
        gameManager ??= GetGameManager();
        
        int price = currentCorporation.ParValue * amount;

        if (gameManager.game.shares[currentCorporation] < amount)
        {
            gameManager.game.cash += currentCorporation.ParValue * gameManager.game.shares[currentCorporation];
            gameManager.game.shares[currentCorporation] = 0;
            return;
        }
        
        gameManager.game.cash += price;
        gameManager.game.shares[currentCorporation] -= amount;
    }
}