using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyBehavior>();
        if (enemy)
        {
            enemy.TakeHit(30);
        }
    }
}
