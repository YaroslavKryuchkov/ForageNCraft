using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCollect : MonoBehaviour
{
    private List<Resource> resourceList = new List<Resource>();

    [SerializeField]
    private Text text;

    public void AddResource(Resource res)
    {
        resourceList.Add(res);
        ChangeText();
    }

    public void RemoveResource(Resource res)
    {
        resourceList.Remove(res);
        ChangeText();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && resourceList.Count > 0)
        {
            resourceList.Last().PickUp();
            resourceList.RemoveAt(resourceList.Count - 1);
            ChangeText();
        }
    }

    void ChangeText()
    {
        text.text = resourceList.Count > 0 ? "Press E to collect " + resourceList.Last().GetName() : "";
    }
}
