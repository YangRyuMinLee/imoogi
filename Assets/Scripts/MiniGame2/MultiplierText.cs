using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Minigame2
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class MultiplierText : MonoBehaviour
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
            text.text = String.Format(originString, MingameData.Instance.currentMultiplier);
        }
    }
}