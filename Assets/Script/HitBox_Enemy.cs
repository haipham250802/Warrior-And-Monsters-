using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_Enemy : MonoBehaviour
{
    private Enemy m_Enemy;
    private Info_Bar m_Info;

    [Header("Parametes")]
    public float damage;
    private bool isAttack;

    private void Start()
    {
        m_Enemy = FindObjectOfType<Enemy>();
        m_Info = FindObjectOfType<Info_Bar>();
    }
    private void Update()
    {
        attack();
    }
    void attack()
    {
        if (m_Enemy.IsAttack)
        {
            m_Enemy.Anm.SetBool("isAttackEnemy", true);
            m_Enemy.IsAttack = false;
        }
        else if (!m_Enemy.IsAttack)
        {
            m_Enemy.Anm.SetBool("isAttackEnemy", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.LogWarning("Da cham");
            m_Info.UpdateHp(damage);
        }
    }
    public float getDamage()
    {
        return damage;
    }
}
