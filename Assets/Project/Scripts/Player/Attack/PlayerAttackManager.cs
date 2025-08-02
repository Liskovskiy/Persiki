using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    private Vector2 _targetPosition;
    public void Initialize()
    {
        Debug.Log("Player Attack Manager Init");
    }
    public void AttackTarget(Vector2 targetPosition)
    {
        _targetPosition = targetPosition;
    }
    private void FixedUpdate()
    {
        
    }
}
