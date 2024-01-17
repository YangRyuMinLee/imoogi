using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrashScripts : MonoBehaviour
{
    public TextMeshProUGUI rankText;
    int count = 1;
    void OnTriggerEnter2D(Collider2D o)
    {
        count--;
        if(count == 0)
        {
            if (o.tag == "Horse1")
            {
                rankText.gameObject.SetActive(true);
                rankText.text = "1�� �� �¸�!";
                gameObject.GetComponent<CrashScripts>().enabled = false;
            }
            else if (o.tag == "Horse2")
            {
                rankText.gameObject.SetActive(true);
                rankText.text = "2�� �� �¸�!";
                gameObject.GetComponent<CrashScripts>().enabled = false;
            }
            else if (o.tag == "Horse3")
            {
                rankText.gameObject.SetActive(true);
                rankText.text = "3�� �� �¸�!";
                gameObject.GetComponent<CrashScripts>().enabled = false;
            }
            else if (o.tag == "Horse4")
            {
                rankText.gameObject.SetActive(true);
                rankText.text = "4�� �� �¸�!";
                gameObject.GetComponent<CrashScripts>().enabled = false;
            }
        }
    }
}