using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class QuestItem
{
    public QuestData questData;
    public int count;
    public string title;
    public bool started;
    public QuestSlot questSlot;
    public QuestType type;
    public int targetCount;

    public QuestItem(QuestData questData)
    {
        this.questData = questData;
        this.type = questData.type;
        this.targetCount = questData.targetCount;
        title = questData.title;
    }

    private void OnEnable()
    {
        Inventory.OnInventoryChange += AddToStack;
    }

    public void AddToStack(List<InventoryItem> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemData == questData.itemData)
            {
                count++;
            }
        }
    }

    public void RemoveFromStack()
    {
   //     stackSize--;
    }

}

