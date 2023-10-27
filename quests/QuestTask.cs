using System;
using UnityEngine;

public class QuestTask : MonoBehaviour
{
    public static event HandleTaskCompleted OnTaskCompleted;
    public delegate void HandleTaskCompleted(QuestData questData);
   
    
    public QuestData currentQuestData;

    public void DoTask()
    {
        Debug.Log("QUEST TASK: DoTask()");
        OnTaskCompleted?.Invoke(currentQuestData);
    }
}
