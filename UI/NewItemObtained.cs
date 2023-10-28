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
    private bool isOpen = false;

    void Start()
    {
        icon.sprite = null;
        itemName.text = "";
        itemDescription.text = "";
        itemObtainedPanel.SetActive(false);
    }

    public void Show()
    {
        itemObtainedPanel.SetActive(true); 

        icon.sprite = itemData.icon;
        itemName.text = itemData.name;
        itemDescription.text = itemData.description;
        isOpen = true;
    }

     void Update(){
          if(isOpen && Input.GetKeyDown(KeyCode.Escape)){
          isOpen = false;
          itemObtainedPanel.SetActive(false);
        }   
    }


    void Hide()
    {
        isOpen = false;
        itemObtainedPanel.SetActive(false);
    }

}
