using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrashScripts : MonoBehaviour
{
    public TextMeshProUGUI rankText;
    int count = 0;

    void OnTriggerEnter2D(Collider2D o)
    {
        count++;
        
        if (count == 1)
        {
            TrigerOn(o);
            gameObject.GetComponent<CrashScripts>().enabled = false;
        }
    }
    void TrigerOn(Collider2D o)
    {
        rankText.gameObject.SetActive(true);
        rankText.text = o.gameObject.name;
        Debug.Log(o.gameObject.name);
    }
}