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

    //TODO взаимодействовать с объектами через E -- также как с НПС -- когда мы в определенном радиусе
    //получается есть два типа UI -- те что через клик и те что через кнопку взаимодействия -- это не странно?
    //задания лучше показывать на экране -- для начала всегда 
    //меню настроек можно открывать через кнопку -- посмотреть как это работает в ведьмаке

    void Update()
    {
        if (player != null)
        {
            bool playerInRange = Vector2.Distance(transform.position, player.transform.position) < 2f;

            bool panelShouldBeShown = playerInRange && Input.GetKeyDown(KeyCode.E) && panel.isIteractableByKey;

            if (panelShouldBeShown)
            {
                Debug.Log("this panel could be shown");
                panel.ShowMenu();
            }
        }
    }
}
