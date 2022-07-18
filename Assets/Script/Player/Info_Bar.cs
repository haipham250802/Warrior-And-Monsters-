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
    private float maxHp;
    private float maxMP;
    public float maxXp;

    float curHP;
    float curMP;
    public float CurHP { get => curHP; set => curHP = value; }
    public float CurMP { get => curMP; set => curMP = value; }

    Player m_player;
    UImanager m_UI;

    void Start()
    {
        m_player = FindObjectOfType<Player>();
        m_UI = FindObjectOfType<UImanager>();

        m_UI.SetNumhealth(curHP);

        maxHp = m_player.MaxHealth;
        maxMP = m_player.MaxMP;
        curHP = maxHp;
        curMP = maxMP;
        FillHP.maxValue = maxHp;
        FillMP.maxValue = maxMP;
        FillXP.maxValue = maxXp;
    }
    private void Update()
    {
        m_UI.SetNumhealth(curHP);
        m_UI.SetNumMP(CurMP);
    }
    public void TakeHp(float TakeDamage)
    {
        curHP -= TakeDamage;
        FillHP.value = curHP;
    }
    public void TakeMP(float TakeMana)
    {
        curMP -= TakeMana;
        FillMP.value = curMP;
    }
    public float getHP()
    {
        return maxHp;
    }
    public float getMP()
    {
        return maxMP;
    }
    public void SetHp(float Hp)
    {
        curHP = Hp;
        if(curHP <= 0)
        {
            curHP = 0;
        }
        FillHP.value = curHP;
    }
    public void SetMp(float Mp)
    {
        CurMP = Mp;
        if(CurMP <= 0)
        {
            CurMP = 0;
        }
        FillMP.value = curMP;
    }
}
