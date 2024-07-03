using System;
using TMPro;
using UnityEngine;

namespace Minigame3
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CountText : MonoBehaviour
    {
        private TextMeshProUGUI text;
        private string originString;

        private void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
            originString = text.text;
        }

        private void Update()
        {
            text.text = String.Format(originString, MinigameData.Instance.count);
        }
    }
}