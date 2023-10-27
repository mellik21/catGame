using System;
using UnityEngine;

public class Item : MonoBehaviour, ICollectable
{
	public static event HandleItemCollected OnItemCollected;
	public delegate void HandleItemCollected(ItemData itemData);

    public AudioSource audio;
	public ItemData currentItemData;

	public QuestTask questTask;

	public void Collect()
	{
		
		OnItemCollected?.Invoke(currentItemData);
		audio.Play();

		if(questTask != null)
		{
			questTask.DoTask();
		}

        Destroy(gameObject);
    }
}
