using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public static PlayerAttackManager Instance { get; private set; }
    private Vector2 _targetPosition;
    public event Action<Vector2> OnAttackRequest;
    public void Initialize()
    {
        Debug.Log("Player Attack Manager Init");
        Instance = this;

    }
    public void AttackTarget(Vector2 targetPosition)
    {
        _targetPosition = targetPosition;
        OnAttackRequest?.Invoke(targetPosition);
    }
    private void FixedUpdate()
    {
        
    }
}
