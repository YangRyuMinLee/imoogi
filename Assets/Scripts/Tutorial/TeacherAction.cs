using System;
using System.Threading.Tasks;
using UnityEngine;

public abstract class TeacherAction : ScriptableObject
{
    protected TutorialGameManager game;
    protected TeacherManager acter;

    public void Init(GameManagerBase gameManager, TeacherManager acter)
    {
        this.game = gameManager as TutorialGameManager;
        this.acter = acter;
    }

    public virtual void Init()
    {
    }
    
    public virtual void Act()
    {
    }
}