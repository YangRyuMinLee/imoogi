using System;
using System.Collections.Generic;

[Serializable]
public class Game
{
    public int cash;
    public Dictionary<Corporation, int> shares;
    public IEnumerable<Corporation> Corporations => shares.Keys;

    public int ShareAssets
    {
        get
        {
            int total = 0;
            foreach (var i in shares)
            {
                total += i.Key.ParValue * i.Value;
            }
            return total;
        }
    }

    public int Assets => ShareAssets + cash;


    public void Tick()
    {
        foreach (Corporation i in Corporations)
        {
            i.Tick();
        }
    }
}
