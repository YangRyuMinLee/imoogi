using System;

[Serializable]
public struct SceneTransitionData
{
    public bool newGame;
    public bool loadFile;
    public Game game;
    public long moneyIncrease;
}

public static class SceneTransitionDataStorage
{
    public static SceneTransitionData data;

    static SceneTransitionDataStorage() {
        data.loadFile = true;
        data.newGame = true;
    }
}
