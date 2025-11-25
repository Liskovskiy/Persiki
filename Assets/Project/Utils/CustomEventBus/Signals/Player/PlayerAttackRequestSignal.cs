using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRequestSignal
{
    public readonly Vector2 targetPosition;
    public PlayerAttackRequestSignal(Vector2 newTargetPosition)
    {
        targetPosition = newTargetPosition;
    }
}
