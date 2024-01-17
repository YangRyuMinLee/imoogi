using UnityEngine;
using TMPro;

public class ButtonClickManager : MonoBehaviour
{
    public TextMeshProUGUI titletext;
    public TextMeshProUGUI selectxt;
    public GameObject btnoff;
    public GameObject horsemove;
    private GameObject Score;
    public int selectedHorse;
    public GameObject betting;
    public GameObject backButton;

    public void HorseOnClick(int horse)
    {
        selectedHorse = horse;
        horsemove.GetComponent<Horsemove>().enabled = true;
        titletext.gameObject.SetActive(false);
        selectxt.gameObject.SetActive(false);
        btnoff.SetActive(false);
        betting.SetActive(false);
        backButton.SetActive(false);
    }
}
