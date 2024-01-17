using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrashScripts : MonoBehaviour
{
    public TextMeshProUGUI rankText;
    //public GameObject 
    int count = 1;
    void OnTriggerEnter2D(Collider2D o)
    {
        count--;
        if(count == 0)
        {
            if (o.tag == "Horse1")
                HorseCon_1(o);

            else if (o.tag == "Horse2")
                HorseCon_2(o);

            else if (o.tag == "Horse3")
                HorseCon_3(o);

            else if (o.tag == "Horse4")
                HorseCon_4(o);
        }
    }

    void HorseCon_1(Collider2D o)
    {
        rankText.gameObject.SetActive(true);
        rankText.text = "1锅 富 铰府!";
        gameObject.GetComponent<CrashScripts>().enabled = false;
    }
    void HorseCon_2(Collider2D o)
    {
        rankText.gameObject.SetActive(true);
        rankText.text = "2锅 富 铰府!";
        gameObject.GetComponent<CrashScripts>().enabled = false;
    }
    void HorseCon_3(Collider2D o)
    {
        rankText.gameObject.SetActive(true);
        rankText.text = "3锅 富 铰府!";
        gameObject.GetComponent<CrashScripts>().enabled = false;
    }
    void HorseCon_4(Collider2D o)
    {
        rankText.gameObject.SetActive(true);
        rankText.text = "4锅 富 铰府!";
        gameObject.GetComponent<CrashScripts>().enabled = false;
    }
}