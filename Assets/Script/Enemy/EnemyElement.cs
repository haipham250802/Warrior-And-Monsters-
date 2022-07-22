using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElement : MonoBehaviour
{
    public EnemyBehavior[] enemyBehaviors;

    private void OnValidate()
    {
        enemyBehaviors = GetComponentsInChildren<EnemyBehavior>();
    }
    private void Update()
    {
        enemyBehaviors = GetComponentsInChildren<EnemyBehavior>();
    }
    public int GetSizeEnemyBehaviors()
    {
        return enemyBehaviors.Length;
    }
}
