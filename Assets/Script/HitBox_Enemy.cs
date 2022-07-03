using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox_Enemy : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.LogWarning("Da cham");
        }
    }
}
