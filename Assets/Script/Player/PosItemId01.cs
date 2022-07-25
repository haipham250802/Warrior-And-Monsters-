using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosItemId01 : MonoBehaviour
{
    private GameObject prefab;
    private GameObject WeponItems;

    bool isHideWepon1;
    private void Start()
    {

    }
    void Update()
    {
        UpdateView();
    }
    private void UpdateView()
    {
        if (DataPlayer.IsOwnWeponWithId(1) && isHideWepon1 == false)
        {
            prefab = Resources.Load<GameObject>($"Wepon/{1}");
            WeponItems = Instantiate(prefab, transform.position, Quaternion.identity);
            isHideWepon1 = true;
        }
        else if(!DataPlayer.IsOwnWeponWithId(1))
        {
            Destroy(prefab.gameObject);
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
