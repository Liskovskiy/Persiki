using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;

public class RenderWeapon : Render
{
    [SerializeField] protected AnimationClip _idleClip;
    protected EventBus _eventBus;
    protected void InitRenderWeapon()
    {
        InitRender();
        _eventBus = ServiceLocator.Current.Get<EventBus>();
    }
}
