using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    [SerializeField] public TextMeshProUGUI labelText;
    [SerializeField] public TextMeshProUGUI stackSizeText;

    public void WasClicked()
    {
        Debug.Log("WAS CLICKED!");
        GameObject craftPanel =  GameObject.Find("CookingPanel");
        transform.parent = craftPanel.transform;
        transform.position = craftPanel.transform.position;

    }

    public void ClearSlot()
    {
        icon.enabled = false;
        labelText.enabled = false;
        stackSizeText.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
       
        if (item == null)
        {
            ClearSlot();
            return;
        }

        icon.enabled = true;
        labelText.enabled = true;
        stackSizeText.enabled = true;


        icon.sprite = item.itemData.icon;
        labelText.text = item.itemData.displayName;
        stackSizeText.text = item.stackSize.ToString();



    }

}