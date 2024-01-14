using System.Collections.Generic;
using UnityEngine;

public class StockMarket : MonoBehaviour
{
    private List<Corporation> corporations;
    
    public void Start()
    {
        InitStockMarket();
    }

    public void InitStockMarket()
    {
        corporations = new();
    }
    
    public List<Corporation> GetCorporations() => corporations;
}
