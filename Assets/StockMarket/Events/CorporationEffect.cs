using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CorporationEffect", menuName = "Event/CorporationEffect")]
public class CorporationEffect : Event{
    public List<mxmnRateIncrease>MXMNrateIncreases;

    [Serializable]
    public struct mxmnRateIncrease
    {
        public float maxIncreaseRateIncrease;//가장 크개 증가하는 량
        public float minIncreaseRateIncrease;//가장 작게 증가하는 량
        public CorporationType type;//회사
    }

    public override void Act(Game game)
    {
        foreach(mxmnRateIncrease mxmn in MXMNrateIncreases) {
            foreach (Corporation i in game.Corporations){
                if (i.Type != mxmn.type) continue;
                i.maxIncreaseRate += mxmn.maxIncreaseRateIncrease;
                i.minIncreaseRate += mxmn.minIncreaseRateIncrease;
            }
        }
    }

    public override void End(Game game)
    {
        foreach (mxmnRateIncrease mxmn in MXMNrateIncreases){
            foreach (Corporation i in game.Corporations){
                if (i.Type != mxmn.type) continue;
                i.maxIncreaseRate -= mxmn.maxIncreaseRateIncrease;
                i.minIncreaseRate -= mxmn.minIncreaseRateIncrease;
            }
        }
    }
}