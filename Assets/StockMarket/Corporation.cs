using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Corporation
{
    private string name; // 회사 이름
    private CorporationType type; // 회사 종류
    private long parValue; // 액면가
    public float maxIncreaseRate = 0.02f; // 틱 당 최대 증가/감소률
    public float minIncreaseRate = -0.02f; // 틱 당 최소 증가/감소률
    public float EffectedMaxIncreaseRate{
        get {
            float total = maxIncreaseRate;
            effects.ForEach(x => total += x.maxIncreaseRateIncrease);
            return total;
        }
    }
    public float EffectedMinIncreaseRate{
        get {
            float total = minIncreaseRate;
            effects.ForEach(x => total += x.minIncreaseRateIncrease);
            return total;
        }
    }
    public List<long> priceHistory;

    public string Name => name;
    public CorporationType Type => type;
    public long ParValue => parValue;

    private List<CorporationEffect> effects;

    public Corporation(string name, CorporationType type, long initialPrice)
    {
        this.name = name;
        this.type = type;
        this.parValue = initialPrice;

        priceHistory = new();
        priceHistory.Add(parValue);
        effects = new();
    }

    public void Tick()
    {
        IncreaseParValueByRate(UnityEngine.Random.Range(EffectedMinIncreaseRate, EffectedMaxIncreaseRate));
        priceHistory.Add(parValue);
        for (int i = 0; i < effects.Count; i++) {
            var effect = effects[i];
            effect.timer++;
            effects[i] = effect;
        }
        effects.RemoveAll(x => x.timer >= x.duration);
    }


    /// <param name="rate"> 퍼센트 / 100 </param>
    public void IncreaseParValueByRate(float rate)
    {
        parValue = (long)Mathf.Round(parValue * (1 + rate));
    }

    public void ApplyEffect(CorporationEffect effect) {
        effects.Add(effect);
    }
}
