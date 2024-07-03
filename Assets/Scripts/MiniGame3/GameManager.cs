using UnityEngine;

namespace Minigame3
{
    public class GameManager : MonoBehaviour
    {
        public void Click()
        {
            MinigameData.Instance.AddCount(1);
            if (MinigameData.Instance.count >= 100)
            {
                MinigameData.Instance.SetMoney();
            }
        }
    }
}