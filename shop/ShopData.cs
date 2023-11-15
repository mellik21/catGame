using System;
using UnityEngine;

[CreateAssetMenu]
public class ShopData : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public ShopItemCategory category;
    public string description;
    public int price;
    public ShopData parent;
    public ShopData child;

    public ShopItemType itemType;
}

public enum ShopItemCategory
{
    Machine, Decoration
}

public enum ShopItemType
{
    Microscope, OtherMachine
}