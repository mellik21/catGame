using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public bool isOpen = false;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update(){
        if(isOpen && Input.GetKeyDown(KeyCode.Escape)){
             Close();
        }   
    }

    public void ShowMenu()
    {   
        Debug.Log("SHOW MENU");
        isOpen = true;
        gameObject.SetActive(true);

    }

    public void Close(){
         Debug.Log("HIDE MENU");
        isOpen = false;
        gameObject.SetActive(false);
    }

}
