using UnityEngine;

abstract class Event : ScriptableObject
{
    [Header("Global")]
    public Sprite headerSprite;
    public string header;
    [Multiline] public string description;

    public abstract void Act();
}
