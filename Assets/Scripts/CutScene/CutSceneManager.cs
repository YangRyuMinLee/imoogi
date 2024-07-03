using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    
    public void MuteAudio()
    {
        source.Stop();
    }
    
    public void ChangeScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
