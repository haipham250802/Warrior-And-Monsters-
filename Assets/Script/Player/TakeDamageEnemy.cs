using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamageEnemy : MonoBehaviour
{
    public int NumEnemy;
    Player m_Player;
    EnemyElement m_enemyElement;

    public FloatingPoint m_floatingPoint;

    private void Start()
    {
        m_Player = FindObjectOfType<Player>();
        m_enemyElement = FindObjectOfType<EnemyElement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyBehavior>();
        var boss = collision.gameObject.GetComponent<BossBehavior>();
        if (enemy)
        {
            if (m_Player.IsCanUseSkill00)
            {
                m_floatingPoint.textMesh().text = $"-{DataPlayer.GetDamage1()}" ;
                enemy.TakeHit(DataPlayer.GetDamage1());
                m_Player.IsCanUseSkill00 = false;
            }
            else if (m_Player.IsCanUseSkill01)
            {
                m_floatingPoint.textMesh().text = $"-{DataPlayer.GetDamage2()}";
                enemy.TakeHit(DataPlayer.GetDamage2());
                m_Player.IsCanUseSkill01 = false;
            }
        }
        if(boss && m_enemyElement.GetSizeEnemyBehaviors() == 0)
        {
            if (m_Player.IsCanUseSkill00)
            {
                m_floatingPoint.textMesh().text = $"-{DataPlayer.GetDamage1()}";
                boss.TakeHit(DataPlayer.GetDamage1());
                m_Player.IsCanUseSkill00 = false;
            }
            else if (m_Player.IsCanUseSkill01)
            {
                m_floatingPoint.textMesh().text = $"-{DataPlayer.GetDamage2()}";
                boss.TakeHit(DataPlayer.GetDamage2());
                m_Player.IsCanUseSkill01 = false;
            }
        }
    }
}
