using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponId1 : MonoBehaviour
{
    private float damage1;

    public float Damage1 { get => damage1; set => damage1 = value; }

    private void Awake()
    {
        damage1 = 10;
    }
}
