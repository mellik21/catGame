using System;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
	public string displayName;
	public Sprite icon;
	public ItemType type;
	public Rarity rarity;
	public string description;
}

public enum ItemType
{
	Ingredient, Food
}

public enum Rarity
{
	Gold, Silver, Iron
}
