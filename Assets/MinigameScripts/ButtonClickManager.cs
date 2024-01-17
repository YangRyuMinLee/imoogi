using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonClickManager : MonoBehaviour
{
    public TextMeshProUGUI titletext;
    public TextMeshProUGUI selectxt;
    public GameObject btnoff;
    public GameObject obj; 
    
    public void HorseOnClick_1()
    {

        obj.GetComponent<Horsemove>().enabled = true;
        titletext.gameObject.SetActive(false);
        selectxt.gameObject.SetActive(false);
        btnoff.gameObject.SetActive(false);
    }
    public void HorseOnClick_2()
    {
        obj.GetComponent<Horsemove>().enabled = true;
        titletext.gameObject.SetActive(false);
        selectxt.gameObject.SetActive(false);
        btnoff.gameObject.SetActive(false);
    }
    public void HorseOnClick_3()
    {
        obj.GetComponent<Horsemove>().enabled = true;
        titletext.gameObject.SetActive(false);
        selectxt.gameObject.SetActive(false);
        btnoff.gameObject.SetActive(false);
    }
    public void HorseOnClick_4()
    {
        obj.GetComponent<Horsemove>().enabled = true;
        titletext.gameObject.SetActive(false);
        selectxt.gameObject.SetActive(false);
        btnoff.gameObject.SetActive(false);
    }
}
