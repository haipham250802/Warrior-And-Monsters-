using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamageEnemy : MonoBehaviour
{
    Player m_Player;
    public FloatingPoint m_floatingPoint;

    float damage1, damage2;
    private void Start()
    {
        m_Player = FindObjectOfType<Player>();
        
       
    }
    private void Update()
    {
        damage1 = m_Player.Damage1;
        damage2 = m_Player.Damage2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyBehavior>();
        var boss = collision.gameObject.GetComponent<BossBehavior>();
        if (enemy)
        {
            if (m_Player.IsCanUseSkill00)
            {
                m_floatingPoint.textMesh().text = $"-{damage1}" ;
                enemy.TakeHit(damage1);
                m_Player.IsCanUseSkill00 = false;
            }
            else if (m_Player.IsCanUseSkill01)
            {
                m_floatingPoint.textMesh().text = $"-{damage2}";
                enemy.TakeHit(damage2);
                m_Player.IsCanUseSkill01 = false;
            }
        }
        if(boss)
        {
            if (m_Player.IsCanUseSkill00)
            {
                m_floatingPoint.textMesh().text = $"-{damage1}";
                boss.TakeHit(damage1);
                m_Player.IsCanUseSkill00 = false;
            }
            else if (m_Player.IsCanUseSkill01)
            {
                m_floatingPoint.textMesh().text = $"-{damage2}";
                boss.TakeHit(damage2);
                m_Player.IsCanUseSkill01 = false;
            }
        }
    }
}
