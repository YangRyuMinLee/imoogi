using UnityEngine;
using UnityEngine.Search;

[CreateAssetMenu(fileName = "New Event", menuName = "Event/Event")]
public class Event : ScriptableObject
{
    [Header("Global")]
    [SearchContext("a:assets t:Sprite", SearchViewFlags.GridView)] public Sprite headerSprite;
    public string header;
    [Multiline] public string description;
    public string buttonText;

    public virtual void Act(Game game) { }
}
