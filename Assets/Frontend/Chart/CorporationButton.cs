using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CorporationButton : MonoBehaviour
{
    private Button button;
    [HideInInspector] public Corporation corporation;
    [SerializeField] new private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI amount;

    public void SetCorporation(Corporation newCorporation)
    {
        corporation = newCorporation;
        
        SetName(corporation.Name);
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            MainChartManager chartManager = GameObject.FindObjectsOfType<MainChartManager>()[0];
            chartManager.currentCorporation = corporation;
            chartManager.Tick();
        });
    }
    
    public void SetName(string newName)
    {
        name.text = newName;
    }

    public void SetAmount(int newAmount)
    {
        amount.text = newAmount + " 주";
    }
}