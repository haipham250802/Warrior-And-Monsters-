using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMP : MonoBehaviour
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
            int MaxMp = DataPlayer.GetMaxMP();
            int Mp = DataPlayer.GetMP();
            Mp = Mp + (m_enemy.ID * 10);
            if (Mp < MaxMp)
            {
                DataPlayer.SetMP(Mp);
            }
            else if (Mp > MaxMp)
            {
                Mp = MaxMp;
                DataPlayer.SetMP(Mp);
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
