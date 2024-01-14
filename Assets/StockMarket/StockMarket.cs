using System.Collections.Generic;
using UnityEngine;

public class StockMarket : MonoBehaviour
{
    private List<Corporation> _corporations; 
    
    public void Start()
    {
        InitStockMarket();
    }

    public void InitStockMarket()
    {
        _corporations = new();
    }
    
    public List<Corporation> GetCorporations() => _corporations;
}