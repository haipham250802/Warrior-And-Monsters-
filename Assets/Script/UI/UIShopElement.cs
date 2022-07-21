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

    public GameObject Dialog1;
    public GameObject Dialog2;
    private void Awake()
    {
        PurchaseBtn.onClick.AddListener(OnPurchase);
    }
  
    public void SetData(int id)
    {
        this.id = id;
        cost = id * 500;

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
        var isPurchase = DataPlayer.CheckEnoughtCoin(cost);
        if (isPurchase)
        {
            Dialog2.SetActive(true);
            DataPlayer.AddWepon(id);
            DataPlayer.SubCoin(cost);
        }
        else
        {
            Dialog1.SetActive(true);
        }    
        UpdateView();
    }
}
