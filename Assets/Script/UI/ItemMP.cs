using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMP : MonoBehaviour
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
            float MaxMp = m_Info.getMP();
            float Mp = m_Info.CurMP;
            Mp = Mp + 10;
            if (Mp < MaxMp)
            {
                m_Info.SetMp(Mp);
            }
            else if (Mp > MaxMp)
            {
                Mp = MaxMp;
                m_Info.SetMp(Mp);
            }
            Destroy(gameObject);
        }

    }
}
