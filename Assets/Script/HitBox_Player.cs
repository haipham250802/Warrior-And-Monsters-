using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_Player : MonoBehaviour
{
    HealthBar_Enemy m_health;
    Player m_Player;
    private void Start()
    {
        m_health = FindObjectOfType<HealthBar_Enemy>();
        m_Player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            if (m_Player.IsCanUseSkill00)
            {
                m_health.setHealth(m_Player.Damage1);
            }
            else if(m_Player.IsCanUseSkill01)
            {
                m_health.setHealth(m_Player.Damage2);
            }
        }
    }
}
