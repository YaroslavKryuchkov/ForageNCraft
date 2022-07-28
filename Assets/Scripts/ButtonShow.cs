using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShow : MonoBehaviour
{
    void Awake()
    {
        TrapsManager.OnCraftBegin += Show;
        TrapsManager.OnCraftEnd += Hide;
        Hide();
    }

    void Show()
    {
        this.gameObject.SetActive(true);
    }

    void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
