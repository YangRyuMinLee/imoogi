using System;
using UnityEngine;

[Serializable]
public class Corporation
{
    private string name; // 회사 이름
    private CorporationType type; // 회사 종류
    private int parValue; // 액면가
    
    public string Name => name;
    public CorporationType Type => type;
    public int ParValue
    {
        get => parValue;
        set
        {
            parValue = value;
        }
    }

    public Corporation(string name, CorporationType type, int initialPrice)
    {
        this.name = name;
        this.type = type;
        this.parValue = initialPrice;
    }

    public void Tick()
    {
        parValue = Mathf.RoundToInt(parValue * UnityEngine.Random.Range(0.95f, 1.05f)); // Temporary Implementation
    }
}
