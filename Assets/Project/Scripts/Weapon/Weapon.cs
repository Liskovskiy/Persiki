using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;

public abstract class Weapon : MonoBehaviour
{
    public float Damage;
    protected EventBus _eventBus;
    protected Animator _animator;
    protected void InitWeapon()
    {
        _animator = GetComponentInChildren<Animator>();
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _eventBus.Subscribe<PlayerAttackRequestSignal>(Attack);
    }
    protected virtual void OnDisable()
    {
        if (_eventBus != null) _eventBus.Unsubscribe<PlayerAttackRequestSignal>(Attack);
    }
    public abstract void Attack(PlayerAttackRequestSignal signal);
}
