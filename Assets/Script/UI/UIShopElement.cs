using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopElement : MonoBehaviour
{
    public int id;
    public int cost;

    public Text costTxt;
    public Button PurchaseBtn;
    public GameObject Coin;


    private void Awake()
    {
        PurchaseBtn.onClick.AddListener(OnPurchase);
    }
  
    public void SetData(int id)
    {
        this.id = id;
        cost = id * 200;

        UpdateView();
    }

   
    private void UpdateView()
    {
        var isOwned = DataPlayer.IsOwnWeponWithId(id);
        if(isOwned)
        {
            PurchaseBtn.enabled = false;
            costTxt.text = "Owned";
            Coin.SetActive(false);
        }
        else
        {
            Coin.SetActive(true);
            PurchaseBtn.enabled = true;
            costTxt.text = cost.ToString();
        }
    }
    private void OnPurchase()
    {
        DataPlayer.AddWepon(id);

        UpdateView();
    }
}
