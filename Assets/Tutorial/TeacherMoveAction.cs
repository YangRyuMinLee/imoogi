using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Tutorial/TeacherMoveAction", fileName = "TeacherMoveAction")]
public class TeacherMoveAction : TeacherAction
{
    [SerializeField] private float time;
    [SerializeField] private Vector2 target;
    
    public override void Act()
    {
        acter.StartCoroutine(InterpolateMove());
    }

    IEnumerator InterpolateMove()
    {
        float dt = 0f;
        Vector2 startPos = acter.transform.localPosition;
            
        while (dt <= time)
        {
            dt += Time.deltaTime;
            Vector2 pos = Vector2.Lerp(startPos, target, dt / time);
            acter.transform.localPosition = pos;
            
            yield return null;
        }
    }
}
