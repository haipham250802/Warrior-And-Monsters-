using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosItemId2 : MonoBehaviour
{
    private GameObject prefab;
    private GameObject WeponItems;

    bool isHideWepon2;
    private void Start()
    {
        
    }
    void Update()
    {
        UpdateView();
    }
    private void UpdateView()
    {
        if (DataPlayer.IsOwnWeponWithId(2) && isHideWepon2 == false)
        {
            prefab = Resources.Load<GameObject>($"Wepon/{2}");
            WeponItems = Instantiate(prefab, transform.position, Quaternion.identity);
            isHideWepon2 = true;
        }
        if (Player.instance && WeponItems)
        {
            WeponItems.transform.position = transform.position;
            if (Player.instance.MoveSpeed1 > 0 && WeponItems.transform.localScale.x < 0)
            {
                Vector3 theScale = WeponItems.transform.localScale;
                theScale.x *= -1;
                WeponItems.transform.localScale = theScale;
            }
            else if (Player.instance.MoveSpeed1 < 0 && WeponItems.transform.localScale.x > 0)
            {
                Vector3 theScale = WeponItems.transform.localScale;
                theScale.x *= -1;
                WeponItems.transform.localScale = theScale;
            }
        }
    }

}
