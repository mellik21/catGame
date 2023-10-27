using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for all buttons etc
public class OpenUIPanel : MonoBehaviour
{
    public UIMenu panel;
      
    public void OpenPanel()
    {
        Debug.Log("OPEN PANEL!");
    //    Time.timeScale = 0f;
        panel.ShowMenu();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CheckIfSomethingWasClicked();
    }

    //craftMenu:"Microscope"
    //inventory: "InventoryButton"
    private void CheckIfSomethingWasClicked()
    {
        Debug.Log("SMTH WAS CLICKED!");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider && hit.collider.name == gameObject.name)
        {
            Debug.Log("I WAS CLICKED!");
            panel.ShowMenu();
        }

    }
}
