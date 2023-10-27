/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishQuest : MonoBehaviour
{
    public GameObject dialogueBox;
    public QuestList questList;
    public AudioSource audio;
    public string questName;
    public QuestItem currentQuest;
    public bool canBeCompleted = false;

    public NewItemObtained itemObtained;
    private bool wasObtainedOnce = false;

    private void OnEnable()
    {
        Dialogue.OnCurrentDialogFinished += FinishQuestAndObtain;
    }

    void Update()
    {
        if (currentQuest.type == QuestType.DIALOGUE)
        {
            FinishDialogueQuest();
        }

        if (currentQuest.type == QuestType.COLLECTABLE)
        {
            FinishCollectableQuest();
        }
    }

    void FinishQuestAndObtain()
    {
        Debug.Log("itemObtained != null && !wasObtainedOnce :" +  itemObtained != null && !wasObtainedOnce);
        if (itemObtained != null && !wasObtainedOnce)
        {   
            itemObtained.Show();
        }

        currentQuest.questSlot.FinishQuest();
        audio.Play();
       // gameObject.SetActive(false);
    }

    private void FinishDialogueQuest()
    {
        foreach (QuestItem item in questList.quests)
        {
            if (item.title == questName)
            {
                currentQuest = item; break;
            }
        }

        bool dialogueActive = dialogueBox.activeInHierarchy;

        if (itemObtained != null && dialogueActive)
        {
      //      Debug.Log("FQ: WAITING FOR THE END OF THE DIALOG");
            return;
        }

        if (dialogueActive && currentQuest.started)
        {
            if (itemObtained != null)
            {
                itemObtained.Show();
            }

   //         Debug.Log("FQ: DIALOGUE IS ACTIVE AND QUEST WAS STARTED");
            currentQuest.questSlot.FinishQuest();
            audio.Play();
            gameObject.SetActive(false);
        }
    }

    public void FinishCollectableQuest()
    {
        if (currentQuest.started && currentQuest.count == currentQuest.targetCount)
        {
            canBeCompleted = true;
        }
    }

    *//*    public void FinishQuestIfItCanBeFinished()
        {
            if (canBeCompleted)
            {
                currentQuest.questSlot.FinishQuest();
                audio.Play();
            }
        }*//*
}
*/