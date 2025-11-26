using CustomEventBus;
using CustomEventBus.Signals;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RangedWeapon : Weapon
{
    // ????????? ???? ????? ?????????? ?? ??????? ????
    private EventBus _eventBus;
    [SerializeField] private GameObject _arrow;
    public void Start()
    {
        Init();
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        //_eventBus.Subscribe<PlayerAttackRequestSignal>(Attack);
    }

    void OnDisable()
    {
        if (_eventBus != null) _eventBus.Unsubscribe<PlayerAttackRequestSignal>(Attack);
    }
    public override void Attack(PlayerAttackRequestSignal signal)
    {
        Vector2 targetPosition = signal.targetPosition;

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
