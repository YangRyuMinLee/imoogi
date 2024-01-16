using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class VerticalPriceIndicatorManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> indicators;
    
    public void UpdateIndicator(IEnumerable<int> history)
    {
        int min = history.Min();
        int max = history.Max();
        
        int size = indicators.Count;
        float d = 0;
        float interval = 1f / (size-1);

        indicators[0].text = min.ToString();
        for (int i = 1; i < size; i++)
        {
            d += interval;
            indicators[i].text = Mathf.Round(((max - min) * d + min)).ToString();
        }
    }
}
