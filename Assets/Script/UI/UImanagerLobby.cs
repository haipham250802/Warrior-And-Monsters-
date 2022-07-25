using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UImanagerLobby : MonoBehaviour
{
    public Text NumHealthTxt;
    public Text NumMPTxt;
    public Text NumXPTxt;
    public Text NumGoldTxt;
    public Text NumDiamondTxt;
    public Text NumLevelTxt;
    public Text NumAttack1Txt;
    public Text NumAttack2Txt;
    

    public Slider SliderExp;

    bool isCanPlusDamageWepon1;
    bool isCanPlusDamageWepon2;

    WeponId1 m_wp1;
    WeponId2 m_wp2;
    private void Awake()
    {
        m_wp1 = FindObjectOfType<WeponId1>();
        m_wp2 = FindObjectOfType<WeponId2>();
    }
    private void Update()
    {
        UpdateView();

        Debug.Log($"damage1 = { DataPlayer.GetDamage1()} , Damage2 = {DataPlayer.GetDamage2()}");

    }
    public void UpdateView()
    {
        NumHealthTxt.text = DataPlayer.GetMaxHP().ToString();
        NumMPTxt.text = DataPlayer.GetMaxMP().ToString();
        NumXPTxt.text = DataPlayer.GetXP() + " / " + DataPlayer.GetMaxXP().ToString();

        NumGoldTxt.text = DataPlayer.GetCoin().ToString();
        NumDiamondTxt.text = DataPlayer.GetDiamond().ToString();
        NumLevelTxt.text = "LEVEL " + DataPlayer.GetLevel().ToString();

        SliderExp.maxValue = DataPlayer.GetMaxXP();
        SliderExp.value = DataPlayer.GetXP();
        
        UpdateDamage();
    }
    public void UpdateDamage()
    {
        if (DataPlayer.IsOwnWeponWithId(1) && DataPlayer.GetIsPlusDamage1() == false && m_wp1)
        {
            int damage1 = DataPlayer.GetDamage1();
            damage1 += m_wp1.Damage1;
            DataPlayer.SetDamage1(damage1);
            isCanPlusDamageWepon1 = true;
            DataPlayer.SetIplusDamage1(isCanPlusDamageWepon1);
        }
        if (DataPlayer.IsOwnWeponWithId(2) && DataPlayer.GetIsPlusDamage2() == false && m_wp2)
        {
            int damage2 = DataPlayer.GetDamage2();
            damage2 += m_wp2.Damage2;
            DataPlayer.SetDamage2(damage2);
            isCanPlusDamageWepon2 = true;
            DataPlayer.SetIplusDamage2(isCanPlusDamageWepon2);

        }
        NumAttack1Txt.text = DataPlayer.GetDamage1().ToString();
        NumAttack2Txt.text = DataPlayer.GetDamage2().ToString();
    }
}
