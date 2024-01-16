using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event/Event")]
public class Event : ScriptableObject
{
    [Header("Global")]
    public Sprite headerSprite;
    public string header;
    [Multiline] public string description;
    public string buttonText;

    public virtual void Act(Game game) { }
    public virtual void End(Game game) { }
}
