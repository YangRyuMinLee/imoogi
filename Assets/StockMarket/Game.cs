using System;
using System.Collections.Generic;

[Serializable]
public class Game
{
    public TimeProgress time;
    public int cash;
    public Dictionary<Corporation, int> shares;
    public IEnumerable<Corporation> Corporations => shares.Keys;

    public Queue<Event> remainingEvents;

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

    public Game(){
        shares = new();
        remainingEvents = new();
        cash = 1000000;
    }

    public void Tick()
    {
        foreach (Corporation i in Corporations)
        {
            i.Tick();
        }
        time.progress++;
    }

    public void TriggerEvent(Event e)
    {
        e.Act(this);
        remainingEvents.Enqueue(e);
    }
}
