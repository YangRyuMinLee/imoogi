using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Tutorial/TeacherMoveAction", fileName = "TeacherMoveAction")]
public class TeacherMoveAction : TeacherAction
{
    [SerializeField] private float time;
    [SerializeField] private Vector2 target;
    
    public override void Act()
    {
        TeacherManager action = acter.GetComponent<TeacherManager>();
        action.StartCoroutine(InterpolateMove());
    }

    IEnumerator InterpolateMove()
    {
        float dt = 0f;
            
        while (dt <= time)
        {
            dt += Time.deltaTime;
            Vector2 pos = Vector2.Lerp(acter.transform.localPosition, target, dt / time);
            acter.transform.localPosition = pos;
            yield return null;
        }
    }
}
