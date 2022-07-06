using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_Enemy : MonoBehaviour
{
    private Enemy m_Enemy;
    private Info_Bar m_Info;
    private Player m_player;

    [Header("Parametes")]
    public float damage;
    private bool isAttack;

    private void Start()
    {
        m_Enemy = FindObjectOfType<Enemy>();
        m_Info = FindObjectOfType<Info_Bar>();
        m_player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        attack();
    }
    void attack()
    {
        if (!m_player.IsGameOver)
        {
            if (m_Enemy.IsAttack)
            {
                m_Enemy.Anm.SetBool("isAttackEnemy", true);
            }
            else if (!m_Enemy.IsAttack)
            {
                m_Enemy.Anm.SetBool("isAttackEnemy", false);
            }
        }
        else
        {
            m_Enemy.Anm.SetBool("isAttackEnemy", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!m_player.IsGameOver)
        {
            if (collision.CompareTag("Player"))
            {
                m_Info.UpdateHp(damage);
                m_player.Getanm().SetBool("isHitDamage", true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_player.Getanm().SetBool("isHitDamage", false);
        }
    }
    public float getDamage()
    {
        return damage;
    }
}
