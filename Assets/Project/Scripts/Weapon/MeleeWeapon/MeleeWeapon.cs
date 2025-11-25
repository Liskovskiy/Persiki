using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;

public class MeleeWeapon : MonoBehaviour
{
    private Animator _animator;
    private EventBus _eventBus;
    private void Start()
    {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _animator = GetComponentInChildren<Animator>();

        _eventBus.Subscribe<PlayerAttackRequestSignal>(Attack);
    }

    private void SetAttackDirection(Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - (Vector2)transform.position;

        float baseAngle = -45f;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                transform.parent.rotation = Quaternion.Euler(0, 0, baseAngle);

            }
            else
            {
                transform.parent.rotation = Quaternion.Euler(0, 180, baseAngle);

            }
        }
        else
        {
            if (direction.y > 0)
            {
                transform.parent.rotation = Quaternion.Euler(0, 180, 90f + baseAngle);
            }
            else
            {
                transform.parent.rotation = Quaternion.Euler(0, 0, -90f + baseAngle);
            }
        }

    }
    void OnDisable()
    {
        _eventBus.Unsubscribe<PlayerAttackRequestSignal>(Attack);
    }
    public void Attack(PlayerAttackRequestSignal signal)
    {
        SetAttackDirection(signal.targetPosition);
        _animator.SetTrigger("AttackEvent");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            _eventBus.Invoke(new EnemyDamagedSignal(enemy, 1));
        }
    }
}
