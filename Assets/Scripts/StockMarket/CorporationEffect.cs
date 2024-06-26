using System;
using UnityEngine;

[Serializable]
public struct CorporationEffect{
    public float maxIncreaseRateIncrease;
    public float minIncreaseRateIncrease;
    public int duration;
    [HideInInspector]
    public int timer;
}
