using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    EnemyBehavior m_enemy;
    public LayerMask PlayerMask;

    public float range;
    private void Start()
    {
        m_enemy = FindObjectOfType<EnemyBehavior>();
    }
    private void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, range, PlayerMask);
        if(col)
        {
            int MaxHp = DataPlayer.GetMaxHP();
            int hp = DataPlayer.GetHP();
            hp = hp + (m_enemy.ID * 10);
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
