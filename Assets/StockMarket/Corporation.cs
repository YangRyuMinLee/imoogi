using System;
using UnityEngine;

[Serializable]
public class Corporation : INotifyPriceChanged
{
    private string name; // 회사 이름
    private CorporationType type; // 회사 종류
    private float parValue; // 액면가
    
    public string Name => name;
    public CorporationType Type => type;
    public float ParValue
    {
        get => parValue;
        set
        {
            // _parValue == value
            if (Mathf.Abs(parValue - value) < float.Epsilon) return;
            
            parValue = value;
            OnPriceChanged?.Invoke(parValue);
        }
    }
    
    [field:NonSerialized]
    public event INotifyPriceChanged.PriceChangedEventHandler OnPriceChanged;
    
    public Corporation(string name, CorporationType type, float initialPrice)
    {
        this.name = name;
        this.type = type;
        this.parValue = initialPrice;
    }
}
