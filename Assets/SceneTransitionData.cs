using System;

[Serializable]
public struct SceneTransitionData
{
    public bool newGame;
}

public static class SceneTransitionDataStorage
{
    public static SceneTransitionData data;
}
