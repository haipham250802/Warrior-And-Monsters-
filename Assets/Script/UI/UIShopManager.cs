using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopManager : MonoBehaviour
{
    public UIShopElement[] ShopElements;
    private void OnValidate()
    {
        if(ShopElements == null || ShopElements.Length == 0)
        {
            ShopElements = GetComponentsInChildren<UIShopElement>();
        }
    }
    private void Awake()
    {
        SetData();
    }
    private void SetData()
    {
        for(int i = 0; i < ShopElements.Length; i++)
        {
            ShopElements[i].SetData(i + 1);
        }
    }
}
