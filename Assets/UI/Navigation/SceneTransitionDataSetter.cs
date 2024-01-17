using UnityEngine;

public class SceneTransitionDataSetter : MonoBehaviour
{
    public SceneTransitionData data;

    public void SetSceneTransitionData()
    {
        SceneTransitionDataStorage.data = data;
    }
}
