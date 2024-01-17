using UnityEngine;

public class MinigameEnder : MonoBehaviour
{
    public ButtonClickManager buttonClickManager;
    public MinigameMoney minigameMoney;
    public CrashScripts crashScripts;
    public GameObject backButton;

    public void End() {
        int selectedHorse = buttonClickManager.selectedHorse;
        int wonHorse = crashScripts.wonHorse;
        Debug.Log(selectedHorse + " " + wonHorse);
        long money = minigameMoney.Money;
        if(selectedHorse == wonHorse){
            SceneTransitionDataStorage.data.moneyIncrease = money * 3L;
        }
        else {
            SceneTransitionDataStorage.data.moneyIncrease = money * -1L;
        }
        SceneTransitionDataStorage.data.loadFile = false;
        backButton.SetActive(true);
    }

}
