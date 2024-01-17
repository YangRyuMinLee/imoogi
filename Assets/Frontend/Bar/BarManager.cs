using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using Random = System.Random;
using Task = System.Threading.Tasks.Task;

public class BarManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI listenText;
    [SerializeField] private List<string> listenList;

    public async void Show(float duration = 0.1f)
    {
        //random get
        int randomNumber = new Random().Next(0, listenList.Count);
        listenText.text = listenList[randomNumber];
        
        await Task.Delay(TimeSpan.FromSeconds(duration));

        listenText.text = string.Empty;
    }
}
