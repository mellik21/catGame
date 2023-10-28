using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class QuestSlot : MonoBehaviour
{
    public Image questMark;
    [SerializeField] public TextMeshProUGUI labelText;
    public bool started;

    private QuestItem questItem;
    private QuestList list;

    private QuestSlot[] slots;

    private Button button;
     
    public GameObject descriptionPanel { get; set; }

    private TextMeshProUGUI d_title;
    private TextMeshProUGUI d_desc;


    private void Start()
    {
        slots = FindObjectsOfType<QuestSlot>();
        list = FindObjectOfType<QuestList>();
    }

    public void OpenQuest()
    {
        d_title = descriptionPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        d_title.text = questItem.title;

        d_desc = descriptionPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        d_desc.text = questItem.questData.description;
    }


    public void ClearDescription()
    {
        d_title = descriptionPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        d_title.text = "";

        d_desc = descriptionPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        d_desc.text = "";
    }

    public void StartNewQuest(QuestItem item)
    {
        if (item == null)
        {
            FinishQuest();
            return;
        }
        item.started = true;
     
        questItem = item;
        item.questSlot = this;

        labelText.text = item.questData.title;
        OpenQuest();
    }

    public void OnQuestClick()
    {   
        slots = FindObjectsOfType<QuestSlot>();
        foreach (QuestSlot slot in slots)
        {
            if (slot != null && slot.started && slot.questMark != null)
            {
                RemoveColor(slot);
            }
        }
        ChangeColor();
        started = true;
    }

    public void FinishQuest()
    {
        list.CompleteQuest(questItem.questData);
        ClearDescription();
    }

    private void ChangeColor()
    {
        gameObject.GetComponent<Image>().color = new Color32(233, 227, 206, 100);
    }

    private void RemoveColor(QuestSlot o)
    {
        o.gameObject.GetComponent<Image>().color = new Color32(0, 0, 22, 100);
    }

}