using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponId2 : MonoBehaviour
{
    private int damage2;

    public int Damage2 { get => damage2; set => damage2 = value; }

    private void Awake()
    {
        damage2 = 20;
    }
}
