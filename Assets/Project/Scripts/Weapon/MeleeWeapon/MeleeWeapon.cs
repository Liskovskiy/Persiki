using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    //IEnumerator WaitForManager()
    //{
    //    while (PlayerAttackManager.Instance == null)
    //        yield return null;

    //    PlayerAttackManager.Instance.OnAttackRequest += Attack;
    //}
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        if (PlayerAttackManager.Instance != null)
            PlayerAttackManager.Instance.OnAttackRequest += Attack;
    }
    //void OnEnable()
    //{
    //    StartCoroutine(WaitForManager());
    //}

    void OnDisable()
    {
        if (PlayerAttackManager.Instance != null)
            PlayerAttackManager.Instance.OnAttackRequest -= Attack;
    }
    public void Attack(Vector2 targetPosition)
    {
        Debug.Log("Attack");
        _animator.SetTrigger("AttackEvent");
    }
}
