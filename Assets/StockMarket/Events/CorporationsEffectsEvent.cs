using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event/CorporationsEffectEvent")]
public class CorporationsEffectsEvent : Event
{
    [Serializable]
    public class CorporationEffectApplication{
        public CorporationType type;
        public CorporationEffect effect;
    }

    public CorporationEffectApplication[] corporationEffectApplications;

    public override void Act(Game game) {
        foreach (var i in corporationEffectApplications) {
            foreach (Corporation j in game.Corporations) {
                if (j.Type == i.type) {
                    j.ApplyEffect(i.effect);
                }
            }
        }
    }
}
