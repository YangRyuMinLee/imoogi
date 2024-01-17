using UnityEngine;

[CreateAssetMenu(menuName = "Tutorial/TeacherToggleGameAction", fileName = "TeacherToggleGameAction")]
public class TeacherToggleGameAction : TeacherAction
{
    public bool status;

    public override void Act()
    {
        game.stop = status;
    }
}