using UnityEngine;

[CreateAssetMenu(fileName = "New CorporationEvent", menuName = "Event/CorporationEvent")]
public class CorporationEvent : Event {

    public CorporationType type;
    public float rate;

    //serializable

    public override void Act(Game game) {
        foreach (Corporation i in game.Corporations)
        {
            if (i.Type == type) {
                i.IncreaseParValueByRate(rate);
            }
        }
    }
}
