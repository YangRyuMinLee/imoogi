using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class TeacherManager : MonoBehaviour
{
    [Serializable]
    public struct ActionWithDate
    {
        public float wait;
        public int year;
        public int month;
        public int day;
        public TeacherAction action;
    }

    [Header("Action"), Tooltip("Please order by tick"), SerializeField]
    private List<ActionWithDate> actions;
    
    private int tickCnt;

    [Header("TalkBalloon")] [SerializeField]
    private TextMeshProUGUI talkballon;

    [SerializeField] private List<Transform> talkballonAttachPositions;

    private GameManagerBase gameManager;

    public GameObject darken;
    public RectTransform image;
    
    public void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManagerBase>();
        gameManager.onTickEvent += Tick;
    }

    public void Tick()
    {
        if (gameManager.GetGame().time.progress % 6 == 1)
        {
            Act();
        }
    }

    public void ChangeAttachPosition(int index)
    {
        talkballon.transform.position = talkballonAttachPositions[index].position;
    }

    public void Say(string newText)
    {
        talkballon.text = newText;
    }

    private async void Act()
    {
        foreach (ActionWithDate action in actions)
        {
            if (!CompareDateTime(gameManager.GetGame().time.dateTime, action.year, action.month, action.day)) continue;
            
            await Task.Delay(TimeSpan.FromSeconds(action.wait));
            action.action.Init(gameManager, this);
            action.action.Act();
        }
    }
    
    private bool CompareDateTime(DateTime dateTime, int year, int month, int day)
    {
        return dateTime.Year == year && dateTime.Month == month && dateTime.Day == day;
    }
}