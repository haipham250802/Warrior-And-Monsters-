using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponId1 : MonoBehaviour
{
    private int damage1;

    public int Damage1 { get => damage1; set => damage1 = value; }

    private void Awake()
    {
        damage1 = 10;
    }
}
