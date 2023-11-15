using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ShopManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public int size;
    public List<ShopSlot> slots;
    public GameObject descriptionPanel;

    public ShopData currentData { get; set; }

    void Start()
    {
        slots = new List<ShopSlot>(size);
    }

    private void OnEnable()
    {
        Shop.OnShopChange += DrawShop;
        //ShopSlot.OnShopSlotClicked += SaveCurrentSlot();
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



}
