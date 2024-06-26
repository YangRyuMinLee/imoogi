using UnityEngine;
using TMPro;
using Math = System.Math;

public class MinigameMoney : MonoBehaviour
{
    public long Money{
        get => money;
        set {
            money = Math.Clamp(value, 1, SceneTransitionDataStorage.data.game.cash);
            moneyText.text = money.ToString("#,##").Replace(',', ' ') + " 여의";
        }

    }
    private long money;
    public TextMeshProUGUI moneyText;


    void Start() {
        Money = SceneTransitionDataStorage.data.game.cash / 10;
    }

    public void IncreaseMoney(int value){
        Money += value;
    }
}
