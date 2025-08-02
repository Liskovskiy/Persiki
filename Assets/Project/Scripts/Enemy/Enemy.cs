using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private EnemyFSM _enemyFsm;
    public void Initialize()
    {
        _enemyFsm = new EnemyFSM();
    }
    private void Update()
    {
        _enemyFsm.FsmRun();

    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy take damage");
        // Here you can add logic to handle the damage taken by the enemy
    }
}
