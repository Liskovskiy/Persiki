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

    void OnDisable()
    {
        AttackManager.Instance.OnAttackRequest -= Attack;
    }
    public void Attack(Vector2 targetPosition)
    {
        Debug.Log("Attack");
        _animator.SetTrigger("AttackEvent");
    }
}
