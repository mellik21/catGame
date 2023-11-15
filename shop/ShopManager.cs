using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class ShopManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public int size;
    public List<ShopSlot> slots;
    public GameObject descriptionPanel;

    public ShopData currentData { get; set; }

    private GameObject microscope;

    void Start()
    {
        slots = new List<ShopSlot>(size);
        microscope = GameObject.Find("Microscope");
    }

    private void OnEnable()
    {
        Shop.OnShopChange += DrawShop;
        ShopSlot.OnShopSlotClicked += SaveCurrentSlot;
    }

    void SaveCurrentSlot(ShopData data)
    {
        this.currentData = data;
    }

    void ResetShop()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }

        slots = new List<ShopSlot>(size);
    }

    void DrawShop(List<ShopData> shop)
    {
        ResetShop();

        for (int i = 0; i < size; i++)
        {
            CreateShopSlot(); //empty ones
            if (shop.Count > i)
            {
                ShopSlot slot = slots[i];

                slot.DrawSlot(shop[i]);
            }
        }
    }

    void CreateShopSlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        ShopSlot newSlotComponent = newSlot.GetComponent<ShopSlot>();
        newSlotComponent.descriptionPanel = descriptionPanel;
        newSlotComponent.Start();
        newSlotComponent.ClearSlot();

        slots.Add(newSlotComponent);
    }

    public void PurchaseItem()
    {

        Debug.Log((microscope != null));
        if (currentData.itemType.ToString() == "Microscope")
        {
            SpriteRenderer micPic = microscope.GetComponent<SpriteRenderer>();
            micPic.sprite = currentData.icon;
            micPic.transform.localScale = Vector2.one;
            microscope.SetActive(true);
        }
    }

}
