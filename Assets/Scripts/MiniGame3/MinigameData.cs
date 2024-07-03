using System;

namespace Minigame3
{
    public class MinigameData : Singleton<MinigameData>
    {
        public int count;

        private void Start()
        {
            SceneTransitionDataStorage.data.moneyIncrease = 0;
        }

        public void AddCount(int cnt)
        {
            count += cnt;
        }
        
        public void SetMoney()
        {
            SceneTransitionDataStorage.data.moneyIncrease += count;
            SceneTransitionDataStorage.data.loadFile = false;
            count = 0;
        }
    }
}