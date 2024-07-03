using UnityEngine;

[CreateAssetMenu(menuName = "Tutorial/TeacherDarkenAnimationAction", fileName = "TeacherDarkenAnimationAction")]
public class TeacherDarkenAnimationAction : TeacherAction
{
    [SerializeField] private string[] animationNames;
    private int index;

    public override void Init()
    {
        index = 0;
    }

    public override void Act()
    {
        acter.darken.GetComponent<Animator>().Play(animationNames[index]);
        index++;
    }
}
