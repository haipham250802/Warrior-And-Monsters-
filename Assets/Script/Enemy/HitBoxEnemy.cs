using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxEnemy : MonoBehaviour
{
    Info_Bar m_inf;
    public float Damage;

    private void Start()
    {
        m_inf = FindObjectOfType<Info_Bar>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if(player)
        {
            m_inf.TakeHp(Damage);
        }
    }
}
