using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestList : MonoBehaviour
{
    public static event Action<List<QuestItem>> OnQuestListChange;

    public static int questsCount = 0;

    public List<QuestItem> quests = new List<QuestItem>();
    private Dictionary<QuestData, QuestItem> questDictionary = new Dictionary<QuestData, QuestItem>();

    private void OnEnable()
    {
        QuestTask.OnTaskCompleted += StartNewQuest;

    }

    private void OnDisable()
    {
        QuestTask.OnTaskCompleted -= CompleteQuest;
    }


    public void StartNewQuest(QuestData questData)
    {
 
        if (!questDictionary.ContainsKey(questData))
        {
            QuestItem quest = new QuestItem(questData);
            quests.Add(quest);
            questsCount++;
            questDictionary.Add(questData, quest);

            OnQuestListChange?.Invoke(quests);
        }

    }

    public void CompleteQuest(QuestData questData) {
        if (questDictionary.TryGetValue(questData, out QuestItem item))
        {
          
            questsCount--;
            quests.Remove(item);

            questDictionary.Remove(questData);
        }

        OnQuestListChange?.Invoke(quests);
    }

}
