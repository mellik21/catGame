using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CraftingMachine : MonoBehaviour
{
    public ShopData shopData;
    public Animator animator;

    private void OnEnable()
    {
        //    ShopManager.OnMachineUpdated += UpdateMachine;
    }

}