using System;
using UnityEngine;

[Serializable]
public class Corporation : INotifyPriceChanged
{
    private string _name; // 회사 이름
    private CorporationType _type; // 회사 종류
    private float _parValue; // 액면가
    
    public string Name => _name;
    public CorporationType Type => _type;
    public float ParValue
    {
        get => _parValue;
        set
        {
            // _parValue == value
            if (Mathf.Abs(_parValue - value) < float.Epsilon) return;
            
            _parValue = value;
            OnPriceChanged?.Invoke(_parValue);
        }
    }
    
    [field:NonSerialized]
    public event INotifyPriceChanged.PriceChangedEventHandler OnPriceChanged;
    
    public Corporation(string name, CorporationType type, float initialPrice)
    {
        _name = name;
        _type = type;
        _parValue = initialPrice;
    }
}