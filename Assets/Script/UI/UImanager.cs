using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public Text NumHealthTxt;
    public Text NumMPTxt;
    public Text NumXPTxt;
    public Text NumGoldTxt;
    public Text NumDiamondTxt;
    public Text NumLevelTxt;

    public Slider sliderXP;
    public Slider sliderHP;
    public Slider sliderMP;

    public GameObject DeadGamePanel;


    void Start()
    {
        DeadGamePanel.SetActive(false);

    }
    private void Update()
    {
        UpdateView();

    }
    public void UpdateView()
    {
        NumHealthTxt.text = DataPlayer.GetHP() + " / " + DataPlayer.GetMaxHP();
        NumMPTxt.text = DataPlayer.GetMP() + " / " + DataPlayer.GetMaxMP();
        NumXPTxt.text = DataPlayer.GetXP().ToString() + " / " + DataPlayer.GetMaxXP();
        NumGoldTxt.text = DataPlayer.GetCoin().ToString();
        NumDiamondTxt.text = DataPlayer.GetDiamond().ToString();
        NumLevelTxt.text = "LV " + DataPlayer.GetLevel().ToString();

        sliderXP.maxValue = DataPlayer.GetMaxXP();
        sliderXP.value = DataPlayer.GetXP();

        sliderHP.maxValue = DataPlayer.GetMaxHP();
        sliderHP.value = DataPlayer.GetHP();

        sliderMP.maxValue = DataPlayer.GetMaxMP();
        sliderMP.value = DataPlayer.GetMP();


    }
 
    public void ShowDeadGame()
    {
        DeadGamePanel.SetActive(true);
    }

}
