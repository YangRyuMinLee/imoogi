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
        public float maxIncreaseRateIncrease;//���� ũ�� �����ϴ� ��
        public float minIncreaseRateIncrease;//���� �۰� �����ϴ� ��
        public CorporationType type;//ȸ��
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