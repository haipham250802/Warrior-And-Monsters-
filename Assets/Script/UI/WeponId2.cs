using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponId2 : MonoBehaviour
{
    private float damage2;

    public float Damage2 { get => damage2; set => damage2 = value; }

    private void Awake()
    {
        damage2 = 20;
    }
}
