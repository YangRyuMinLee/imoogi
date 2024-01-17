using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeacherManager : MonoBehaviour
{
    [Serializable]
    public struct ActionWithTick
    {
        public int year;
        public int month;
        public int day;
        public TeacherAction action;
    }

    [Header("Action"), Tooltip("Please order by tick"), SerializeField]
    private List<ActionWithTick> actions;
    
    private int tickCnt;

    [Header("TalkBalloon")] [SerializeField]
    private TextMeshProUGUI talkballon;

    [SerializeField] private List<Transform> talkballonAttachPositions;

    public void Start()
    {
        GameManagerBase gameManager = GameObject.FindObjectOfType<GameManagerBase>();
        gameManager.onTickEvent += Tick;
        
        // play test
        foreach (ActionWithTick action in actions)
        {
            action.action.Init(gameManager, this);
            action.action.Act();
        }
    }

    public void Tick()
    {
    }

    public void ChangeAttachPosition(int index)
    {
        talkballon.transform.position = talkballonAttachPositions[index].position;
    }

    #region Test In Editor

    [Header("Test"), Space(10), SerializeField]
    private int testIndex;

    [ContextMenu("Change Attach Position")]
    private void ChangeAttachPositionEditor()
    {
        ChangeAttachPosition(testIndex);
    }

    #endregion

    public void Say(string newText)
    {
        talkballon.text = newText;
    }
}