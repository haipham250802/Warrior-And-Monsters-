using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Info_Bar : MonoBehaviour
{
    [Header("Info Bar")]
    public Slider FillHP;
    public Slider FillMP;
    public Slider FillXP;
    // Start is called before the first frame update

    [Header("Parameters")]
    public float maxHp;
    public float maxMP;
    public float maxXp;

    float curHP;
    
    private HitBox_Enemy m_HitBox;

    public float CurHP { get => curHP; set => curHP = value; }

    void Start()
    {
        m_HitBox = FindObjectOfType<HitBox_Enemy>();

        FillHP.maxValue = maxHp;
        FillMP.maxValue = maxMP;
        FillXP.maxValue = maxXp;

        curHP = maxHp;
    }

    public void UpdateHp(float TakeDamage)
    {
        curHP -= TakeDamage;
        FillHP.value = curHP;
    }
    public void UpdateMP(float TakeMana)
    {
        maxMP -= TakeMana;
        FillMP.value = maxMP;
    }
    public float getHP()
    {
        return maxHp;
    }
    public void SetHp(float Hp)
    {
        curHP = Hp;
        FillHP.value = curHP;
    }
}
