using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    Rigidbody2D rb;
    Info_Bar m_Info;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Info = FindObjectOfType<Info_Bar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float MaxHp = m_Info.getHP();
            float hp = m_Info.CurHP;
            hp = hp + 10;
            if (hp < MaxHp)
            {
                m_Info.SetHp(hp);
            }
            else if (hp > MaxHp)
            {
                hp = MaxHp;
                m_Info.SetHp(hp);
            }
            Destroy(gameObject);
        }
        
    }
}
