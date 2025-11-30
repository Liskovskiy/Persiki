using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;

public class RenderRangedWeapon : RenderWeapon
{
    [SerializeField] protected AnimationClip        _attackClip;
    [SerializeField] protected bool                 _pinToCursore = true;
                     private   MousePositionHandler _mousePositionHandler;
                     private   Vector2              _targetPosition;
                     protected bool                 _pinToTarget = false;
    void Start()
    {
        InitRenderWeapon();
        _eventBus.Subscribe<RenderRangedWeaponPlayAttackSignal>(PlayAttackClip);
        _mousePositionHandler = ServiceLocator.Current.Get<MousePositionHandler>();
    }

    public void PlayAttackClip(RenderRangedWeaponPlayAttackSignal signal)
    {
        _targetPosition = _mousePositionHandler.GetCursorePosition();
        _pinToCursore = false;
        _pinToTarget = true;
        PlayAnimationClip(_attackClip, OnAttackAnimationEnd);
    }

    protected void OnAttackAnimationEnd()
    {
        PlayAnimationClip(_idleClip, null, false);
        _eventBus.Invoke(new RenderRangedWeaponFinishAttackSignal());
        _pinToTarget = false;
        _pinToCursore = true;
    }

    private void PinWeaponToCursore()
    {
        Vector3 mouseWorldPos = _mousePositionHandler.GetCursorePosition();
        Vector3 direction = mouseWorldPos - transform.position;

        transform.right = -direction;
        if (direction.x < 0)
            transform.localScale = new Vector3(1, -1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void PinWeaponToTarget()
    {
        Vector3 direction = (Vector3)_targetPosition - transform.position;

        transform.right = -direction;
        if (direction.x < 0)
            transform.localScale = new Vector3(1, -1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void FixedUpdate()
    {
        if (_pinToCursore)  PinWeaponToCursore();
        if (_pinToTarget)   PinWeaponToTarget();
    }
}
