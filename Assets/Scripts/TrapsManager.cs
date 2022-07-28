using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TrapsManager : MonoBehaviour
{
    public static event Action OnCraftBegin;
    public static event Action OnCraftEnd;

    [SerializeField]
    private ResourceManager rm;

    [SerializeField]
    public Text resourceText;

    private bool isCrafting = false;

    [HideInInspector]
    public static int[] trapCount = new int[2] {0,0};

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(isCrafting)
            {
                OnCraftEnd?.Invoke();
                isCrafting = false;
            }
            else
            {
                OnCraftBegin?.Invoke();
                isCrafting = true;
            }
        }
    }

    public void CraftSlowTrap()
    {
        if(ResourceManager.resources["Cube"] > 0 && ResourceManager.resources["Sphere"] > 0)
        {
            ResourceManager.resources["Cube"]--;
            ResourceManager.resources["Sphere"]--;
            trapCount[0]++;
            ChangeText();
            rm.ChangeText();
        }
    }

    public void CraftStopTrap()
    {
        if (ResourceManager.resources["Cube"] > 0 && ResourceManager.resources["Capsule"] > 0)
        {
            ResourceManager.resources["Cube"]--;
            ResourceManager.resources["Capsule"]--;
            trapCount[1]++;
            ChangeText();
            rm.ChangeText();
        }
    }

    public void ChangeText()
    {
        resourceText.text = "You have: " + trapCount[0] + " slow traps and " + trapCount[1] + " stop traps";
    }
}
