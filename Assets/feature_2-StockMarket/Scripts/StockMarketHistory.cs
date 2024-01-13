using System;
using System.Collections.Generic;

[Serializable]
public struct StockMarketHistory
{
    private Dictionary<DateTime, List<Corporation>> _history;
    
    public Dictionary<DateTime, List<Corporation>> History => _history;

    public void Add(DateTime dateTime, List<Corporation> corporations)
    {
        if (_history.ContainsKey(dateTime))
        {
            _history[dateTime] = corporations;
            return;
        }
        _history.Add(dateTime, corporations);
    }
}