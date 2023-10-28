using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDefaultQuest : MonoBehaviour
{
	public QuestList questList;
	public QuestData questData;

    public void Start()
	{
		questList.StartNewQuest(questData);
    }
}
