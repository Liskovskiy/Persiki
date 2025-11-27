using CustomEventBus;
using CustomEventBus.Signals;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private GameObject _arrow;
    Vector2 targetPosition;
    public void Start()
    {
        InitWeapon();
        _eventBus.Subscribe<RenderRangedWeaponFinishAttackSignal>(AttackFinished);
    }
    public override void Attack(PlayerAttackRequestSignal signal)
    {
        targetPosition = signal.targetPosition;
        _eventBus.Invoke(new RenderRangedWeaponPlayAttackSignal());
    }

    public void AttackFinished(RenderRangedWeaponFinishAttackSignal signal)
    {

        Vector3 spawnPos = transform.position;

        Vector2 direction = (targetPosition - (Vector2)spawnPos).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject arrowInstance = Instantiate(_arrow, spawnPos, rotation);

        Rigidbody2D rb = arrowInstance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * 20f;
        }
        Destroy(arrowInstance, 10f);
        _eventBus.Invoke(new PlayerAttackResponseSignal());
    }
}
