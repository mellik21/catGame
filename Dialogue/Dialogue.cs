using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using System;

public class Dialogue : MonoBehaviour
{   
    public TextAsset inkFile;

    #region GameObjects
    public GameObject dialoguePanel;
    private GameObject dialogueBox;
    private TextMeshProUGUI message;
    private TextMeshProUGUI nameTag;
    private Animator portraitAnimator;
    private GameObject optionPanel;
    private GameObject customButton;
    #endregion

    public bool isActive = false;
    private bool waitingForChoice = false;
    public bool isStopped = false;
    public string dialogueName;

    #region Objects for typing
    private string currentMessage;
    static Story story;
    private List<string> tags = new List<string>();
    static Choice choiceSelected;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    #endregion

    public static event Action<string> OnCurrentDialogFinished;


    public void ShowCustomMessage(string _message, string author, string avatarTag)
    {
        InitializeAndShow();
        message.text = _message;
        nameTag.text = author;
        portraitAnimator.Play(avatarTag);
    }

  

    public void StartDialogue()
    {
        Debug.Log("DM: START DIALOGUE");
        if (!isStopped)
        {
            InitializeAndShow();

            isActive = true;
            story = new Story(inkFile.text);

            AdvanceDialogue();
        }    
    }

    private void InitializeAndShow()
    {
        dialoguePanel.SetActive(true);

        optionPanel = dialoguePanel.transform.GetChild(0).gameObject;
        customButton = optionPanel.transform.GetChild(0).gameObject;

        dialogueBox = dialoguePanel.transform.GetChild(1).gameObject;
        dialogueBox.SetActive(true);


        TextMeshProUGUI[] textFields = dialogueBox.GetComponentsInChildren<TextMeshProUGUI>();

        nameTag = textFields[0];
        message = textFields[1];
        portraitAnimator = dialoguePanel.GetComponentInChildren<Animator>();

    }

    public void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            if (story.canContinue)
            {
                AdvanceDialogue();
            }

            if (story.currentChoices.Count != 0)
            {
                StartCoroutine(ShowChoices());
            }

            if (!story.canContinue && story.currentChoices.Count <= 0)
            {
                isStopped = true;
            }
        }

        if (isStopped && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("IS STOPPED!!!!!");
            StopAllCoroutines();
            OnCurrentDialogFinished?.Invoke(dialogueName);

            dialoguePanel.SetActive(false);
        }
    }

    void AdvanceDialogue()
    {
        optionPanel.SetActive(false);

        string currentSentence = story.Continue();
        currentMessage = currentSentence;

        HandleTags();
        StopAllCoroutines();
    
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;

        }
        yield return null;
    }

    IEnumerator ShowChoices()
    {
        if (!waitingForChoice)
        {
            List<Choice> _choices = story.currentChoices;

            for (int i = 0; i < _choices.Count; i++)
            {
                GameObject temp = Instantiate(customButton, optionPanel.transform);
                temp.GetComponent<Text>().text = _choices[i].text;
                temp.AddComponent<Selectable>();
                temp.GetComponent<Selectable>().element = _choices[i];
                temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });
            }

            optionPanel.SetActive(true);
            waitingForChoice = true;
        }
        yield return new WaitUntil(() => { return choiceSelected != null; });

        AdvanceFromDecision();
    }

    public static void SetDecision(object element)
    {
        choiceSelected = (Choice)element;
        story.ChooseChoiceIndex(choiceSelected.index);
    }

    void AdvanceFromDecision()
    {
        waitingForChoice = false;

        for (int i = 1; i < optionPanel.transform.childCount; i++)
        {
            Destroy(optionPanel.transform.GetChild(i).gameObject);
        }
        choiceSelected = null;
        AdvanceDialogue();
    }

    private void HandleTags()
    {
      List<string>  currentTags = story.currentTags;
     
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    nameTag.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    Debug.Log("TAG = "+tagValue);
                    portraitAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }
}
