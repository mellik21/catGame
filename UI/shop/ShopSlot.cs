using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlot : MonoBehaviour
{
    public GameObject descriptionPanel { get; set; }
    private ShopData shopData;

    private Image icon;
    private TextMeshProUGUI labelText;
    private TextMeshProUGUI d_title;
    private TextMeshProUGUI d_desc;
    private Button button;
    private Image background;
    private LayoutElement layoutElement;

    public void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);

        icon = transform.GetChild(0).gameObject.GetComponent<Image>();
        labelText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        button = gameObject.GetComponent<Button>();
        background = gameObject.GetComponent<Image>();
        layoutElement = gameObject.GetComponent<LayoutElement>();
    }

    public void WasClicked()
    {
        ShowDescription();
    }

    public void ClearSlot()
    {
        icon.enabled = false;
        labelText.enabled = false;
    }

    public void DrawSlot(ShopData item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }
        icon.enabled = true;
        icon.sprite = item.icon;

        labelText.enabled = true;
        labelText.text = item.displayName;

        shopData = item;

        button.enabled = true;
        background.enabled = true;
        layoutElement.enabled = true;
    }


    public void ShowDescription()
    {
        d_title = descriptionPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        d_title.text = shopData.displayName;

        d_desc = descriptionPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        d_desc.text = shopData.description;

        Image image = descriptionPanel.transform.GetChild(2).GetComponent<Image>();
        image.sprite = icon.sprite;

        TextMeshProUGUI price = descriptionPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        price.text = shopData.price.ToString() + " TEN";
    }


    public void ClearDescription()
    {
        d_title = descriptionPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        d_title.text = "";

        d_desc = descriptionPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        d_desc.text = "";
    }

}