using System;
using TMPro;
using UnityEngine;

namespace Minigame2
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BetMoneyText : MonoBehaviour
    {
        private TextMeshProUGUI text;

        private void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            text.text = Minigame2.MingameData.Instance.Money.ToString("#,##").Replace(',', ' ') + " 여의";
        }
    }
}