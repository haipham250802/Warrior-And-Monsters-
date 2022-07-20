using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxEnemy : MonoBehaviour
{

    EnemyBehavior[] m_enemyBehavior;
    public int Damage;

    private void Start()
    {
        m_enemyBehavior = FindObjectsOfType<EnemyBehavior>();

    }
    private void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        for (int i = 0; i < m_enemyBehavior.Length; i++)
        {
            if (player && m_enemyBehavior[i].IsAttack)
            {
                Debug.Log("da danh");
                DataPlayer.TakeHP(Damage);
                m_enemyBehavior[i].IsAttack = false;
            }
        }
    }
}
