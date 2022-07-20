using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMP : MonoBehaviour
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
            int MaxMp = DataPlayer.GetMaxMP();
            int Mp = DataPlayer.GetMP();
            Mp = Mp + 10;
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
