using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private bool clickToMenuScene;

    private void Update()
    {
        if (Input.anyKeyDown && clickToMenuScene)
        {
            ChangeScene("MenuScene");
        }
    }

    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}
