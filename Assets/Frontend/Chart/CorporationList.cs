using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CorporationList : MonoBehaviour
{
    [SerializeField] private CorporationButton corporationButtonPrefab;
    private CorporationButton[] buttons;
    private Dictionary<Corporation, int> shares;
    
    private void Start()
    {
        GameManager gameManager = GameObject.FindObjectsOfType<GameManager>()[0];
        shares = gameManager.game.shares;

        InitCorporationsUI();
    }

    public void InitCorporationsUI()
    {
        int size = shares.Keys.Count();
        buttons = new CorporationButton[size];

        for (int i = 0; i < size; i++)
        {
            Corporation corporation = shares.Keys.ToArray()[i];
            
            buttons[i] = Instantiate(corporationButtonPrefab, transform);
            
            buttons[i].SetCorporation(corporation);
            buttons[i].SetAmount(shares[corporation]);
        }
    }

    public void Update()
    {
        int size = shares.Keys.Count();
        
        for (int i = 0; i < size; i++)
        {
            buttons[i].SetAmount(shares[buttons[i].corporation]);
        }
    }
}
