using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public int size;
    public List<QuestItem> currentQuests = new List<QuestItem>();
    private Dictionary<QuestItem, QuestSlot> slotsMap = new Dictionary<QuestItem, QuestSlot>();

    public void Start()
    {
        GameObject existedSlot = GameObject.Find("QuestInList");
        Destroy(existedSlot);
    }

    private void OnEnable()
    {
        QuestList.OnQuestListChange += DrawQuest;
    }

    void DrawQuest(List<QuestItem> items)
    {
        for (int i = 0; i < currentQuests.Count; i++)
        {
            QuestItem currentQuest = currentQuests[i];
            if (!items.Contains(currentQuest))
            {
                RemoveQuest(currentQuest);
            }
        }

        foreach (QuestItem item in items)
        {
            if (!slotsMap.ContainsKey(item))
            {
                QuestSlot slot = CreateNewQuestSlot(item);

                slotsMap[item] = slot;
                slot.StartNewQuest(item);
                currentQuests.Add(item);
            }
        }
    }

    private QuestSlot CreateNewQuestSlot(QuestItem item)
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        QuestSlot newSlotComponent = newSlot.GetComponent<QuestSlot>();
        return newSlotComponent;
    }

    void RemoveQuest(QuestItem item)
    {
        if (slotsMap.ContainsKey(item))
        {
            QuestSlot slot = slotsMap[item];
         
            slotsMap.Remove(item);
            currentQuests.Remove(item);

            Destroy(slot.gameObject);
        }
    }
}
