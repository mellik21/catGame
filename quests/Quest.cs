using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{ 
    //квест прикрепляется к нпс который его дает
    public QuestItem item;
    public QuestManager manager;
    public QuestData questData;
    public Dialogue dialogue;

    public string questName;
    private bool canBeCompleted;
    public AudioSource questCompleted;

    public NewItemObtained itemObtained;
    private bool wasObtainedOnce = false;
    public QuestList questList;
    public bool reward;

    public bool isFinished;
    public string defaultPhrase;

    public bool shouldBeFinishedAfterDialogue = false;

    void Start()
    {
        questName = questData.title;
    }

    private void OnEnable()
    {   

        Dialogue.OnCurrentDialogFinished += FinishQuestAndObtain;
    }

    void FinishQuestAndObtain(string dialogueName)
    {
        if (shouldBeFinishedAfterDialogue)
        {
            if (dialogueName == dialogue.dialogueName)
            {

                if (itemObtained != null && !wasObtainedOnce)
                {
                    itemObtained.Show();
                }

                questList.CompleteQuest(questData);
                questCompleted.Play();
                isFinished = true;
            }
        }
    }

}
