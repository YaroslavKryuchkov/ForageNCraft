using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static Dictionary<string, int> resources = new Dictionary<string, int>();

    [SerializeField]
    private string[] resourceNames;

    [SerializeField]
    public Text resourceText;

    void Awake()
    {
        foreach (string name in resourceNames)
        {
            resources[name] = 0;
        }

        Resource.OnPickUp += AddResource;
    }

    void AddResource(string name)
    {
        resources[name]++;
        ChangeText();
    }

    public void ChangeText()
    {
        resourceText.text = "You have: ";
        foreach (var resource in resources)
        {
            resourceText.text += resource.Value + " " + resource.Key + ", ";
        }
    }
}
