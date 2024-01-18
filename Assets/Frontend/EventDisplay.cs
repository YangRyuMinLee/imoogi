using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventDisplay : MonoBehaviour
{
    [SerializeField] private GameObject newspaper;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private Image headerImage;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private AudioSource soundEffect;

    public void SetEvent(Event e) // Note to self: do not name a class "Event" again
    {
        headerText.text = e.header;
        headerImage.sprite = e.headerSprite;
        descriptionText.text = e.description;
        buttonText.text = e.buttonText;
        newspaper.SetActive(e.header != "");
        soundEffect.Play();
    }
}
