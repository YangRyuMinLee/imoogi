using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VerticalPriceIndicatorManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> indicators;

    private void Start()
    {
        UpdateIndicator(0, 10000);
    }
    

    public void UpdateIndicator(int min, int max)
    {
        int size = indicators.Count;
        float d = 0;
        float interval = 1f / (size-1);

        indicators[0].text = min.ToString();
        for (int i = 1; i < size; i++)
        {
            d += interval;
            indicators[i].text = ((max - min) * d + min).ToString();
        }
    }
}