using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static event Action<List<ShopData>> OnShopChange;

    public List<ShopData> shop = new List<ShopData>();
    public List<ShopData> items;

    public void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log("ADDING NEW SHOP ITEM: " + items[i].displayName);
            shop.Add(items[i]);
        }
        OnShopChange?.Invoke(shop);
    }


    public void Add(ShopData shopData)
    {
        OnShopChange?.Invoke(shop);
    }

    public void Remove(ShopData shopData)
    {
        if (shop.Contains(shopData))
        {
            shop.Remove(shopData);
        }
    }

}
