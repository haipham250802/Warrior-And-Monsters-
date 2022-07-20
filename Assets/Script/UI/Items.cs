using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int MaxHp = DataPlayer.GetMaxHP();
            int hp = DataPlayer.GetHP();
            hp = hp + 10;
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
