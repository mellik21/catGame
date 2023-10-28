using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for all buttons etc
public class OpenUIPanel : MonoBehaviour
{
    public UIMenu panel;
    public Player player;

    public void OpenPanel()
    {
        panel.ShowMenu();
    }

    void Update()
    {
        if (player != null)
        {
            bool playerInRange = Vector2.Distance(transform.position, player.transform.position) < 2f;

            bool panelShouldBeShown = playerInRange && Input.GetKeyDown(KeyCode.E) && panel.isIteractableByKey;

            if (panelShouldBeShown)
            {
                //  Debug.Log("this panel could be shown");
                panel.ShowMenu();
            }
        }
    }
}
