using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FloatingPoint : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb;
    public TextMesh txt;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,0.2f);
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector2.up * Speed;
    }
    public TextMesh textMesh()
    {
        return txt;
    }
}
