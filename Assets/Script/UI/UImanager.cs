using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public Text NumHealth;
    public Text NumMP;

    public Player m_player;
    void Start()
    {
     
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
    public void SetNumMP(float numMP)
    {
        if (NumMP)
        {
            NumMP.text = numMP.ToString() + " / " + m_player.MaxMP.ToString();
        }
    }
}
