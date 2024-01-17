using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManagerBase : MonoBehaviour
{
    public delegate void TickEventHandler();

    public abstract Game GetGame();
    public abstract event TickEventHandler onTickEvent;
}
