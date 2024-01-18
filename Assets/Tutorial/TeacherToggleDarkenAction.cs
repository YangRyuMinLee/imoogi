using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Tutorial/TeacherToggleDarkenAction", fileName = "TeacherToggleDarkenAction")]
class TeacherToggleDarkenAction : TeacherAction
{
    public bool status;
    
    public override void Act()
    {
        acter.darken.SetActive(status);
    }
}