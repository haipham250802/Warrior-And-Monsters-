using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Player m_player;
    private void Start()
    {
        m_player = FindObjectOfType<Player>();
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position,m_player.transform.position, 20 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }    
    }
}
