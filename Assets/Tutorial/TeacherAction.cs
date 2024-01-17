using UnityEngine;

[CreateAssetMenu(menuName = "Tutorial/TeacherAction", fileName = "TeacherAction")]
public class TeacherAction : ScriptableObject
{
    protected TutorialGameManager game;
    protected TeacherManager acter;

    public void Init(GameManagerBase gameManager, TeacherManager acter)
    {
        this.game = gameManager as TutorialGameManager;
        this.acter = acter;
    }
    
    public virtual void Act()
    {
    }
}