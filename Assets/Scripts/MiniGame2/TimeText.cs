using System;
using TMPro;
using UnityEngine;

namespace Minigame2
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TimeText : MonoBehaviour
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
            text.text = String.Format(originString, (int)GameManager.Instance.time);
        }
    }
}