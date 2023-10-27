using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewItemObtained : MonoBehaviour
{
    public ItemData itemData;
    public GameObject itemObtainedPanel;

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;


    void Start()
    {
        icon.sprite = null;
        itemName.text = "";
        itemDescription.text = "";
        itemObtainedPanel.SetActive(false);
    }

    public void Show()
    {

        Debug.Log("NIO: SHOW");
        itemObtainedPanel.SetActive(true); 

        icon.sprite = itemData.icon;
        itemName.text = itemData.name;
        itemDescription.text = itemData.description;

    }

    void Hide()
    {
        Debug.Log("NIO: HIDE");
        itemObtainedPanel.SetActive(false);
    }

}
