using System;
using System.Collections.Generic;

[Serializable]
public class Game
{
    public TimeProgress time;
    public long cash;
    public SerializableDictionary<Corporation, int> shares;
    public IEnumerable<Corporation> Corporations => shares.Keys;

    public List<Event> remainingEvents;
    [NonSerialized] public EventTriggerer eventTriggerer;

    public long ShareAssets
    {
        get
        {
            long total = 0;
            foreach (var i in shares)
            {
                total += i.Key.ParValue * i.Value;
            }
            return total;
        }
    }

    public long Assets => ShareAssets + cash;

    public Game(){
        shares = new();
        remainingEvents = new();
        cash = 1000000;
    }

    public void Tick()
    {
        time.progress++;
        eventTriggerer.TriggerEvents(this);
        foreach (Corporation i in Corporations)
        {
            i.Tick();
        }
    }

    public void TriggerEvent(Event e)
    {
        e.Act(this);
        remainingEvents.Add(e);
    }
}
