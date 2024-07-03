using UnityEngine;
using UnityEngine.UI;

namespace Minigame3
{
    [RequireComponent(typeof(Image))]
    public class ProgressCircle : MonoBehaviour
    {
        [SerializeField] private int maxCount = 100;
        
        private Image image;

        private void Start()
        {
            image = GetComponent<Image>();
        }

        void Update()
        {
            image.fillAmount = (float)MinigameData.Instance.count / maxCount;
        }
    }
}