using System;
using UnityEngine;

public class AttackManager
{
    private AttackManager()
    {

    }
    private static AttackManager _instance;
    public static AttackManager Instance
    {
        get
        {
            if (_instance == null) _instance = new AttackManager();
            return _instance;
        }
    }

    public event Action<Vector2> OnAttackRequest;
    public event Action OnAttackResponse;

    public void AttackResponse()
    {
        OnAttackResponse?.Invoke();
    }

    public void AttackRequest(Vector2 targetPosition)
    {
        OnAttackRequest?.Invoke(targetPosition);
    }
}