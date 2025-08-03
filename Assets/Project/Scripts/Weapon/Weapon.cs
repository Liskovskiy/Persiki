using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float Damage;
    public abstract void Attack(Vector2 targetPosition);
}
