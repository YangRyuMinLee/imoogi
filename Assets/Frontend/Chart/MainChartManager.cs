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
    private Game game;
    
    public enum FilterMode
    {
        All,
        R20,
    }
    private FilterMode filterMode;
    
    private void Start()
    {
        GameManagerBase gameManager = GameObject.FindObjectOfType<GameManagerBase>();
        gameManager.onTickEvent += Tick;
        
        game = gameManager.GetGame();
        currentCorporation = game.Corporations.First();
    }

    public void Tick()
    {
        List<long> priceHistory = currentCorporation.priceHistory;

        if (priceHistory.Count == 0)
        {
            priceHistory = new List<long>();
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
        if (game.cash <= 0) return;

        long price = currentCorporation.ParValue * amount;
        
        if (game.cash < price)
        {
            amount = (int)(game.cash / currentCorporation.ParValue);
            price = currentCorporation.ParValue * amount;
        }
        
        game.cash -= price;
        game.shares[currentCorporation] += amount;
    }

    public void Sell(int amount)
    {
        long price = currentCorporation.ParValue * amount;

        if (game.shares[currentCorporation] < amount)
        {
            amount = game.shares[currentCorporation];
            price = currentCorporation.ParValue * amount;
        }
        
        game.cash += price;
        game.shares[currentCorporation] -= amount;
    }
}
