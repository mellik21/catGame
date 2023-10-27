using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCrafting : MonoBehaviour
{
    public GameObject craftingPanel;
    private Simulation simulation;
   
    public void StartCraftingDefaultSettings()
    {
        simulation = craftingPanel.gameObject.GetComponent<Simulation>();
        //TODO remove all child elements of our main crafting panel
        SlimeSettings settings = new SlimeSettings();

     //   Debug.Log("START CRAFTING! OUR SETTINGS: "+ settings.ToString());

        simulation.StartSimulation(settings);
    }
}
