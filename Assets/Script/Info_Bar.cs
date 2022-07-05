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

    private HitBox_Enemy m_HitBox;
    void Start()
    {
        m_HitBox = FindObjectOfType<HitBox_Enemy>();

        FillHP.maxValue = maxHp;
        FillMP.maxValue = maxMP;
        FillXP.maxValue = maxXp;
    }

    public void UpdateHp(float TakeDamage)
    {
        maxHp -= TakeDamage;
        FillHP.value = maxHp;
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
}
