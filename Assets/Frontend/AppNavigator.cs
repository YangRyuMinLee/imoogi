using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppNavigator : MonoBehaviour
{
    [SerializeField] private GameObject initialApp;

    public GameObject EnabledApp{
        get => enabledApp;
        set {
            enabledApp?.SetActive(false);
            enabledApp = value;
            enabledApp?.SetActive(true);
        }
    }

    private GameObject enabledApp;


    void Awake() {
        EnabledApp = initialApp;
    }
}
