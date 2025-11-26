using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;

public abstract class Weapon : MonoBehaviour
{
    public float Damage;
    private EventBus _eventBus;
    protected void Init()
    {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _eventBus.Subscribe<PlayerAttackRequestSignal>(Attack);
    }
    public abstract void Attack(PlayerAttackRequestSignal signal);
}
