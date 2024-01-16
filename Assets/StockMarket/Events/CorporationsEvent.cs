using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Corporations Event", menuName = "Event/Corporations Event")]
public class CorporationsEvent : Event
{
    public List<CorporationRate> corporationRates;

    [Serializable]
    public struct CorporationRate
    {
        public CorporationType type;//ȸ��
        public float rate;//���� ��������
    }

    public override void Act(Game game)
    {
        foreach (CorporationRate cor in corporationRates){
            foreach (Corporation i in game.Corporations){
                if (i.Type == cor.type)
                    i.IncreaseParValueByRate(cor.rate);
            }
        }
    }
}
