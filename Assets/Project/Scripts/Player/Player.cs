using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public void Initialize()
    {
        Debug.Log("Player Init");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player take damage");
    }
}
