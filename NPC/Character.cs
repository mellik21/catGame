using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public GameObject dialogueBox;
    public List<Quest> quests = new List<Quest>();
    public GameObject player;

    private bool playerInRange = false;
    private bool isTalking = false;
    private Quest currentQuest;

    public string name;
    public string defaultAvatarTag;
    public Sprite avatar;

    void Start()
    {
        UpdateCurrentQuest();
    }

    void Update()
    {  
        isTalking = dialogueBox.gameObject.activeInHierarchy;
        playerInRange = Vector2.Distance(transform.position, player.transform.position) < 2f;

        bool dialogShouldBeStarted = currentQuest != null && !isTalking && playerInRange && Input.GetKeyDown(KeyCode.E);

        if (dialogShouldBeStarted)
        {
            Debug.Log("DIALOG SHOULD START!!");
            Dialogue dialogue = currentQuest.dialogue;
       
            if (dialogue.isStopped)
            {
                if (currentQuest.isFinished)
                {
                    isTalking = false;
                    quests.Remove(currentQuest);
                    UpdateCurrentQuest();
                    return;
                }
                else
                {
                    dialogue.ShowCustomMessage(currentQuest.defaultPhrase, name, defaultAvatarTag);
                }
            }

            dialogue.StartDialogue();
           
            currentQuest.questList.StartNewQuest(currentQuest.questData);
        }
    }

    private void UpdateCurrentQuest()
    {   
        if (quests.Count > 0)
        {        
            currentQuest = quests[0];
        }
        else
        {
            currentQuest = null;
        }
    }
}
