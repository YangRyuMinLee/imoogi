using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private Image dateTextFill;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private TextMeshProUGUI assetText;

    public void SetDate(TimeProgress timeProgress) {
        dateText.text = timeProgress.ToString();
    }

    public void SetTimerFill(TimeProgress timeProgress, float progress) {
        dateTextFill.fillAmount = progress;
    }

    public void SetSpeed(bool paused, float speed) {
        if (paused) {
            speedText.text = "PAUSED";
        }
        else {
            speedText.text = new string('>', Mathf.RoundToInt(speed));
        }
    }

    public void SetCash(int value) {
        cashText.text = value.ToString("#,##").Replace(',', ' ') + " 유동여의";
    }

    public void SetAsset(int value) {
        assetText.text = value.ToString("#,##").Replace(',', ' ') + " 총여의";
    }
}
