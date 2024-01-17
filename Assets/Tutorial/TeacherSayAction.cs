using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Tutorial/TeacherSayAction", fileName = "TeacherSayAction")]
public class TeacherSayAction : TeacherAction
{
    [Serializable]
    public struct StringWithDuration
    {
        public string text;
        public float duration;
        public int talkBallonPosIndex;
    }
    [SerializeField] private List<StringWithDuration> textList;
    
    public override async void Act()
    {
        foreach (var stringWithDuration in textList)
        {
            acter.Say(stringWithDuration.text);
            acter.ChangeAttachPosition(stringWithDuration.talkBallonPosIndex);
            await Task.Delay(TimeSpan.FromSeconds(stringWithDuration.duration));
        }
    }
}