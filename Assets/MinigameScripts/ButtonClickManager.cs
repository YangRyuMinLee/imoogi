using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ButtonClickManager : MonoBehaviour
{
    public TextMeshProUGUI titletext;
    public TextMeshProUGUI selectxt;
    public GameObject btnoff;
    public GameObject horsemove;
    private GameObject Score;

    public void HorseOnClick_1()
    {
        horsemove.GetComponent<Horsemove>().enabled = true;
        titletext.gameObject.SetActive(false);
        selectxt.gameObject.SetActive(false);
        btnoff.gameObject.SetActive(false);
    }
    public void HorseOnClick_2()
    {
        horsemove.GetComponent<Horsemove>().enabled = true;
        titletext.gameObject.SetActive(false);
        selectxt.gameObject.SetActive(false);
        btnoff.gameObject.SetActive(false);
    }
    public void HorseOnClick_3()
    {
        horsemove.GetComponent<Horsemove>().enabled = true;
        titletext.gameObject.SetActive(false);
        selectxt.gameObject.SetActive(false);
        btnoff.gameObject.SetActive(false);
    }
    public void HorseOnClick_4()
    {
        horsemove.GetComponent<Horsemove>().enabled = true;
        titletext.gameObject.SetActive(false);
        selectxt.gameObject.SetActive(false);
        btnoff.gameObject.SetActive(false);
    }
}
