using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainChartManager : MonoBehaviour
{
    [HideInInspector] Corporation currentCorporation;
    [SerializeField] private ChartDrawer chart;
    [SerializeField] private VerticalPriceIndicatorManager verticalPriceIndicator;

    private void Start()
    {
        GameManager gameManager = GameObject.FindObjectsOfType<GameManager>()[0];
        currentCorporation = gameManager.game.Corporations.ToList()[0];
    }

    public void Update()
    {
        chart.DrawChart(currentCorporation.priceHistory);
        verticalPriceIndicator.UpdateIndicator(currentCorporation.priceHistory);
    }
}