using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ContinueDisabler : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();

        bool interactable = File.Exists(Application.persistentDataPath + "/imoogi.json");

        button.interactable = interactable;
    }
}
