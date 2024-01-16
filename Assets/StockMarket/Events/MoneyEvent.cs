using UnityEngine;

[CreateAssetMenu(fileName = "New MoneyEvent", menuName = "Event/MoneyEvent")]
public class MoneyEvent : Event
{
    public long money;
    public override void Act(Game game){
        game.cash += money;
    }
}
