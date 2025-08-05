using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        AttackManager.Instance.OnAttackRequest += Attack;
    }

    private void SetAttackDirection(Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - (Vector2)transform.position;

        float baseAngle = -45f;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, baseAngle);

            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, baseAngle);

            }
        }
        else
        {
            if (direction.y > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 90f + baseAngle);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, -90f + baseAngle);
            }
        }

    }
    void OnDisable()
    {
        AttackManager.Instance.OnAttackRequest -= Attack;
    }
    public void Attack(Vector2 targetPosition)
    {
        SetAttackDirection(targetPosition);
        _animator.SetTrigger("AttackEvent");
    }
}
