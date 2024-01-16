using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EventTriggerer", menuName = "EventTriggerer")]
public class EventTriggerer : ScriptableObject{

    [Serializable]
    public struct TimeEventTrigger {
        public Event e; // Note to self again, never ever name a class "Event"
        public int year;
        public int month;
        public int day;
        public float probability;
    }

    [Serializable]
    public struct RandomEventTrigger {
        public Event e;
    }

    [Serializable]
    public struct RepeatEventTrigger {
        public Event e;
    }


    [SerializeField] private TimeEventTrigger[] timeEventTriggers;
    [SerializeField] private RandomEventTrigger[] randomEventTriggers;
    [SerializeField] private RepeatEventTrigger[] repeatEventTriggers;

    public void TriggerEvents(Game game){
        TriggerTimeEvents(game);
        TriggerRandomEvents(game);
    }

    private void TriggerTimeEvents(Game game) {
        foreach (var i in timeEventTriggers) {
            if (game.time.progress % 6 == 0 && CompareDateTime(game.time.dateTime, i.year, i.month, i.day)) {
                if (UnityEngine.Random.Range(0f, 1f) <= i.probability) {
                    game.TriggerEvent(i.e);
                }
            }
        }
    }

    private bool CompareDateTime(DateTime dateTime, int year, int month, int day)
    {
        return dateTime.Year == year && dateTime.Month == month && dateTime.Day == day;
    }


    private void TriggerRandomEvents(Game game) {
        if (game.time.progress % 6 == 0 & game.time.dateTime.Day == 15) {
            game.TriggerEvent(randomEventTriggers[UnityEngine.Random.Range(0, randomEventTriggers.Length)].e);
        }
    }
}
