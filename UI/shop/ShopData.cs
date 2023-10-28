using System;
using UnityEngine;

[CreateAssetMenu]
public class ShopData : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public ShopItemType type;
    public string description;
    public int price;
    public ShopData parent;
    public ShopData child;
}

public enum ShopItemType
{
    Machine, Decoration
}