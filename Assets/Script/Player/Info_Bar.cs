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
    public float CurHP { get => curHP; set => curHP = value; }
    Player m_player;

    void Start()
    {
        m_player = FindObjectOfType<Player>();

        maxHp = m_player.MaxHealth;
        maxMP = m_player.MaxMP;
        curHP = maxHp;
        FillHP.maxValue = maxHp;
        FillMP.maxValue = maxMP;
        FillXP.maxValue = maxXp;

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
