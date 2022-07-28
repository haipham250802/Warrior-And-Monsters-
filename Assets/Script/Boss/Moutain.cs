using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moutain : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject,1f);
        }
    }
}

