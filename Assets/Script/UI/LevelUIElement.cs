using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIElement : MonoBehaviour
{
    public int id;
    public Text NumLV;
    public Button PurChaseBtn;
    public GameObject Lock;

    private void Awake()
    {

    }
    public void SetData(int id)
    {
        this.id = id;
        NumLV.text = id.ToString();

        UpdateView();
    }
    void UpdateView()
    {
        var isOwnedLv = DataPlayer.IsOwnLvWithId(id);
        var CurLevel = DataPlayer.GetLevel();
        if(isOwnedLv)
        {
            Lock.SetActive(false);
            PurChaseBtn.enabled = false;
        }
        else
        {
            gameObject.SetActive(true);
            PurChaseBtn.enabled = true;
        }
        if(CurLevel >= id)
        {
            DataPlayer.AddLvWithId(CurLevel);
        }
    }
}
