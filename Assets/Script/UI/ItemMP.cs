using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMP : MonoBehaviour
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
}
