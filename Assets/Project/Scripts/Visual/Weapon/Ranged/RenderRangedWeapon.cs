using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;

public class RenderRangedWeapon : RenderWeapon
{
    [SerializeField] protected AnimationClip _attackClip;
    void Start()
    {
        InitRenderWeapon();
        _eventBus.Subscribe<RenderRangedWeaponPlayAttackSignal>(PlayAttackClip);
    }

    public void PlayAttackClip(RenderRangedWeaponPlayAttackSignal signal)
    {
        PlayAnimationClip(_attackClip, OnAttackAnimationEnd);
    }

    protected void OnAttackAnimationEnd()
    {
        PlayAnimationClip(_idleClip, null, false);
        _eventBus.Invoke(new RenderRangedWeaponFinishAttackSignal());
    }
}
