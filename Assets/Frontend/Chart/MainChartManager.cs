using System;
using UnityEngine;

public class MainChartManager : MonoBehaviour
{
    public Corporation currentCorporation;
    [SerializeField] private ChartDrawer chart;
    [SerializeField] private VerticalPriceIndicatorManager verticalPriceIndicator;

    public void Update()
    {
    }
}