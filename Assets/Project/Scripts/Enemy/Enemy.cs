using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public EnemyCollision enemyCollision;
    private EnemyDamageFSM _enemyFsm;
    public void Initialize()
    {
        enemyCollision = GetComponent<EnemyCollision>();
        _enemyFsm = new EnemyDamageFSM(enemyCollision);
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
