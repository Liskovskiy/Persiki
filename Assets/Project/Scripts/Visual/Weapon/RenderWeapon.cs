using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;
using Zenject;

public class RenderWeapon : Render
{
    [SerializeField] protected AnimationClip _idleClip;
    protected EventBus _eventBus;

    [Inject]
    public void Init(EventBus eventBus)
    {
        InitRender();
        _eventBus = eventBus;
    }
}
