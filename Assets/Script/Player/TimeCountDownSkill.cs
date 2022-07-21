using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountDownSkill : MonoBehaviour
{
    private Player m_Player;

    [Header("Buttons")]
    public Button SwordAttack_Btn;
    public Button Shield_Btn;
    public Button Buff01_Btn;
    public Button Buff02_Btn;

    [Header("Cooldown Time")]
    public float TimeSkill_00;
    public float TimeSkill_01;
    public float TimeSkill_02;
    public float TimeSkill_03;

    private bool isUsedSkill00;
    private bool isUsedSkill01;
    private bool isUsedSkill02;
    private bool isUsedSkill03;

    public bool IsUsedSkill00 { get => isUsedSkill00; set => isUsedSkill00 = value; }
    public bool IsUsedSkill01 { get => isUsedSkill01; set => isUsedSkill01 = value; }
    int Damage1;
    int Damage2;

    void Start()
    {
        m_Player = FindObjectOfType<Player>();

        Damage1 = DataPlayer.GetDamage1() + 10;
        Damage2 = DataPlayer.GetDamage2() + 20;
    }

    public void SwordAttack()
    {
        if (m_Player.IsCanUseSkill00 && !isUsedSkill00)
        {
            m_Player.Getanm().SetTrigger("isSwordAttack");
            isUsedSkill00 = true;
        }

        if (isUsedSkill00)
        {
            SwordAttack_Btn.GetComponent<Image>().color = Color.gray;
            ColorBlock cb = SwordAttack_Btn.colors;
            cb.pressedColor = Color.white;
            SwordAttack_Btn.colors = cb;
            SwordAttack_Btn.GetComponent<Image>().fillAmount -= 1 / TimeSkill_00 * Time.deltaTime;
            if (SwordAttack_Btn.GetComponent<Image>().fillAmount <= 0)
            {
                m_Player.ClickCount001 = 0;
                SwordAttack_Btn.GetComponent<Image>().fillAmount = 1;
                isUsedSkill00 = false;
                m_Player.IsCanUseSkill00 = false;
                ColorBlock cb1 = SwordAttack_Btn.colors;
                cb1.pressedColor = Color.red;
                SwordAttack_Btn.colors = cb1;
                SwordAttack_Btn.GetComponent<Image>().color = Color.white;
            }

        }
    }
    public void ShieldAttack()
    {
        if (m_Player.IsCanUseSkill01 && !isUsedSkill01)
        {
            m_Player.Getanm().SetTrigger("isShieldAttack");
            isUsedSkill01 = true;
        }

        if (isUsedSkill01)
        {
            Shield_Btn.GetComponent<Image>().color = Color.gray;
            ColorBlock cb = Shield_Btn.colors;
            cb.pressedColor = Color.white;
            Shield_Btn.colors = cb;
            Shield_Btn.GetComponent<Image>().fillAmount -= 1 / TimeSkill_01 * Time.deltaTime;
            if (Shield_Btn.GetComponent<Image>().fillAmount <= 0)
            {
                m_Player.ClickCount011 = 0;
                Shield_Btn.GetComponent<Image>().fillAmount = 1;
                isUsedSkill01 = false;
                m_Player.IsCanUseSkill01 = false;
                ColorBlock cb1 = Shield_Btn.colors;
                cb1.pressedColor = Color.red;
                Shield_Btn.colors = cb1;
                Shield_Btn.GetComponent<Image>().color = Color.white;
            }

        }

    }

    public void Buff01()
    {
        if (m_Player.IsCanUseSkill02 && !isUsedSkill02)
        {
            m_Player.Getanm().SetTrigger("isBuffDamage");
            isUsedSkill02 = true;
        }

        if (isUsedSkill02)
        {
            Buff01_Btn.GetComponent<Image>().color = Color.gray;
            ColorBlock cb = Shield_Btn.colors;
            cb.pressedColor = Color.white;
            Buff01_Btn.colors = cb;
            Buff01_Btn.GetComponent<Image>().fillAmount -= 1 / TimeSkill_02 * Time.deltaTime;

            if (Buff01_Btn.GetComponent<Image>().fillAmount > 0.7f)
            {
                DataPlayer.ReceiveBuffDamage1ToSkill(Damage1);
                DataPlayer.ReceiveBuffDamage2ToSkill(Damage2);
            }
            else if (Buff01_Btn.GetComponent<Image>().fillAmount < 0.7f)
            {
                DataPlayer.SetDamage1(m_Player.CurDamage11);
                DataPlayer.SetDamage2(m_Player.CurDamage21);
            }
            if (Buff01_Btn.GetComponent<Image>().fillAmount <= 0)
            {
                m_Player.ClickCount021 = 0;
                Buff01_Btn.GetComponent<Image>().fillAmount = 1;
                isUsedSkill02 = false;
                m_Player.IsCanUseSkill02 = false;
                ColorBlock cb1 = Buff01_Btn.colors;
                cb1.pressedColor = Color.red;
                Buff01_Btn.colors = cb1;
                Buff01_Btn.GetComponent<Image>().color = Color.white;
            }
        }
    }
    public void Buff02()
    {
        int dem = 0;
        if (m_Player.IsCanUseSkill03 && !isUsedSkill03)
        {
            m_Player.Getanm().SetTrigger("isBuffHp");
            dem++;
            if (dem == 1)
            {
                int MaxHp = DataPlayer.GetMaxHP();
                int hp = DataPlayer.GetHP();
                hp = hp + 50;
                if (hp < MaxHp)
                {
                    DataPlayer.SetHP(hp);
                }
                else if (hp > MaxHp)
                {
                    hp = MaxHp;
                    DataPlayer.SetHP(hp);
                }
            }
            isUsedSkill03 = true;
        }

        if (isUsedSkill03)
        {
            Buff02_Btn.GetComponent<Image>().color = Color.gray;
            ColorBlock cb = Shield_Btn.colors;
            cb.pressedColor = Color.white;
            Buff02_Btn.colors = cb;
            Buff02_Btn.GetComponent<Image>().fillAmount -= 1 / TimeSkill_03 * Time.deltaTime;
            if (Buff02_Btn.GetComponent<Image>().fillAmount <= 0)
            {
                m_Player.ClickCount031 = 0;
                Buff02_Btn.GetComponent<Image>().fillAmount = 1;
                isUsedSkill03 = false;
                m_Player.IsCanUseSkill03 = false;
                ColorBlock cb1 = Buff02_Btn.colors;
                cb1.pressedColor = Color.red;
                Buff02_Btn.colors = cb1;
                Buff02_Btn.GetComponent<Image>().color = Color.white;
                dem = 0;
            }
        }
    }
}
