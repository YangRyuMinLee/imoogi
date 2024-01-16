using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrashScripts : MonoBehaviour
{
    public Text rankText;
    int count = 0;

    private void Awake()
    {
        rankText.gameObject.SetActive(false);
    }
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