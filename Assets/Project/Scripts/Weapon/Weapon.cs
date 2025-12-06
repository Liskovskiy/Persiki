using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;
using Zenject;

public abstract class Weapon : MonoBehaviour
{
    public float Damage;
    protected EventBus _eventBus;
    protected Animator _animator;
    protected DiContainer _container;

    [Inject]
    public void Init(EventBus eventBus, DiContainer container)
    {
        _container = container;
        _eventBus = eventBus;
    }
    protected void InitWeapon()
    {
        _animator = GetComponentInChildren<Animator>();
        //_eventBus = ServiceLocator.Current.Get<EventBus>();
        _eventBus.Subscribe<PlayerAttackRequestSignal>(Attack);
    }
    protected virtual void OnDisable()
    {
        if (_eventBus != null) _eventBus.Unsubscribe<PlayerAttackRequestSignal>(Attack);
    }
    public abstract void Attack(PlayerAttackRequestSignal signal);
}
