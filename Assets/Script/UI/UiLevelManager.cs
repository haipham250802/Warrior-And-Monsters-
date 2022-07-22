using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLevelManager : MonoBehaviour
{
    public LevelUIElement[] levelUIElements;
    private void OnValidate()
    {
        if(levelUIElements == null || levelUIElements.Length == 0)
        {
            levelUIElements = GetComponentsInChildren<LevelUIElement>();
        }
    }
    private void Awake()
    {
        SetData();
    }
    void SetData()
    {
        for(int i = 0; i< levelUIElements.Length; i++)
        {
            levelUIElements[i].SetData(i + 1);
        }
    }
}
