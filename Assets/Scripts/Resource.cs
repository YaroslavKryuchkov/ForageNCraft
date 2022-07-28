using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]
    private string name;

    public static event Action<string> OnPickUp;

    public void PickUp()
    {
        OnPickUp?.Invoke(name);
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider coll)
    {
        ResourceCollect rc = coll.gameObject.GetComponent<ResourceCollect>();
        if (rc != null) rc.AddResource(this);
    }

    void OnTriggerExit(Collider coll)
    {
        ResourceCollect rc = coll.gameObject.GetComponent<ResourceCollect>();
        if (rc != null) rc.RemoveResource(this);
    }

    public string GetName()
    {
        return name;
    }
}
