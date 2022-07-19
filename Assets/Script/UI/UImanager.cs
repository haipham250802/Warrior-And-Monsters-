using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public Text NumHealth;
    public Text NumMP;
    public Text NumGold;
    public Text NumDiamond;
    public GameObject DeadGamePanel;
    public Player m_player;
    [SerializeField]
    private int NumGoldStart;
    [SerializeField]
    private int NumDiamondStart;

    float curGold;
    public int NumDiamondStart1 { get => NumDiamondStart; set => NumDiamondStart = value; }
    public int NumGoldStart1 { get => NumGoldStart; set => NumGoldStart = value; }

    void Start()
    {
        DeadGamePanel.SetActive(false);
        SetNumGold(NumGoldStart);
        SetNumDiamond(NumDiamondStart);
    }
 
    public void SetNumhealth(float numHealth)
    {
        if (NumHealth)
        {
            if(numHealth <= 0)
            {
                numHealth = 0;
            }
            NumHealth.text = numHealth.ToString() + " / " + m_player.MaxHealth.ToString();
        }
    }
    public void SetNumGold(int numGold)
    {
        if(NumGold)
        {
            NumGold.text = numGold.ToString();
        }
    }
    public void SetNumDiamond(int numDiamond)
    {
        if (NumDiamond)
        {
            NumDiamond.text = numDiamond.ToString();
        }
    }

    public void SetNumMP(float numMP)
    {
        if (NumMP)
        {
            NumMP.text = numMP.ToString() + " / " + m_player.MaxMP.ToString();
        }
    }
    public void ShowDeadGame()
    {
        DeadGamePanel.SetActive(true);
    }
}
