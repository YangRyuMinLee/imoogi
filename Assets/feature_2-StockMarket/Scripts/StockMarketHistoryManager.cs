using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class StockMarketHistoryManager
{
    private static readonly string filePath = Application.persistentDataPath + "stockmarket_history";
    public static StockMarketHistory stockMarketHistory;

    private static void CreateFile()
    {
        while (!File.Exists(filePath))
        {
            FileStream fileStream = File.Create(filePath);
            fileStream.Close();
        }
    }

    public static void Save()
    {
        if (!File.Exists(filePath))
        {
            CreateFile();
        }
        
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = File.OpenWrite(filePath))
        {
            formatter.Serialize(fileStream, stockMarketHistory);
        }
    }

    public static void Load()
    {
        if (!File.Exists(filePath)) return;
        
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = File.OpenRead(filePath))
        {
            stockMarketHistory = (StockMarketHistory)formatter.Deserialize(fileStream);
        }
    }

    public static List<Corporation> GetCorporationsOnDate(DateTime date)
    {
        if (!stockMarketHistory.History.ContainsKey(date))
        {
            return null;
        }

        return stockMarketHistory.History[date];
    }
}