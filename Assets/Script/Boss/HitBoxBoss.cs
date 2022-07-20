using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxBoss : MonoBehaviour
{
    BossBehavior[] m_BossBehavior;
    public int Damage;

    private void Start()
    {
        m_BossBehavior = FindObjectsOfType<BossBehavior>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        for (int i = 0; i < m_BossBehavior.Length; i++)
        {
            if (player && m_BossBehavior[i].IsAttack)
            {
                Debug.Log("da danh");
                DataPlayer.TakeHP(Damage);
                m_BossBehavior[i].IsAttack = false;
            }
        }
    }
}
