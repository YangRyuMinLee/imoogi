using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private bool clickToMenuScene;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickToMenuScene)
        {
            ChangeScene("MenuScene");
        }
    }

    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}
