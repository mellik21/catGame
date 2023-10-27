using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class QuestData : ScriptableObject
{
    public string title;
	public string description;
	public int exp;
	public int targetCount;
	public GameObject item;
	public ItemData itemData;
	public QuestType type;
}

public enum QuestType
{
	DIALOGUE, COLLECTABLE
}
