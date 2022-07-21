using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    EnemyBehavior m_enemy;
    private void Start()
    {
        m_enemy = FindObjectOfType<EnemyBehavior>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int MaxHp = DataPlayer.GetMaxHP();
            int hp = DataPlayer.GetHP();
            hp = hp + (m_enemy.ID * 10 );
            if (hp < MaxHp)
            {
                DataPlayer.SetHP(hp);
            }
            else if (hp > MaxHp)
            {
                hp = MaxHp;
                DataPlayer.SetHP(hp);
            }
            Destroy(gameObject);
        }
        
    }
}
