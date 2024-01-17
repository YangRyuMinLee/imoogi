using UnityEngine;

[CreateAssetMenu(menuName = "Tutorial/TeacherRotateAction", fileName = "TeacherRotateAction")]
public class TeacherRotateAction : TeacherAction
{
    public Vector3 angle;

    public override void Act()
    {
        acter.image.transform.rotation = Quaternion.Euler(angle);
    }
}