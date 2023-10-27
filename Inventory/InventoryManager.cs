using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public int size;
    public List<InventorySlot> inventorySlots;

    void Start()
    {
        inventorySlots = new List<InventorySlot>(size);
    }
    
    private void OnEnable()
    {
        //Debug.Log("I_M_ ON ENABLE ");
        Inventory.OnInventoryChange += DrawInventory;
    }

/*   private  void OnDisable()
    {
        Debug.Log("I_M_ ON DISANABLE ");
        Inventory.OnInventoryChange -= DrawInventory;
    }*/

    void ResetInventory()
    {
      //  Debug.Log("RESET INVENTORY");
        //refactor
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }

        inventorySlots = new List<InventorySlot>(size);
    }

    void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();

       // Debug.Log("DRAW INVENTORY: "+ inventory.Count);

        for (int i = 0; i < size; i++) {
            CreateInventorySlot(); //empty ones

            if (inventory.Count > i){
             InventorySlot slot = inventorySlots[i];

             slot.DrawSlot(inventory[i]);
            }
        }

    }

    void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);
    }

}
