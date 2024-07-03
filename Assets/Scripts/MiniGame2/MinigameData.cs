using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigame2
{
    public class MingameData : Singleton<MingameData>
    {
        public long Money{
            get => betMoney;
            set {
                betMoney = Math.Clamp(value, 1, SceneTransitionDataStorage.data.game.cash);
            }
        }
        private long betMoney;
        public int currentMultiplier;

        private void Start()
        {
            Money = SceneTransitionDataStorage.data.game.cash / 10;
        }

        public void SetMoney()
        {
            SceneTransitionDataStorage.data.moneyIncrease = betMoney * (currentMultiplier - 1L);
            SceneTransitionDataStorage.data.loadFile = false;
        }
        
        public void IncreaseMoney(int value){
            Money += value;
        }
    }
}