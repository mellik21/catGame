using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIMenu : MonoBehaviour
{
    public bool isOpen;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowMenu()
    {
        Debug.Log("UIMenu: SHOW MENU!");
        gameObject.SetActive(true);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
