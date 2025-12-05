using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;
using Zenject;

public class RenderRangedWeapon : RenderWeapon
{
    [SerializeField] protected AnimationClip        _attackClip;
    [SerializeField] protected bool                 _pinToCursore = true;
                     private   MousePositionHandler _mousePositionHandler;
                     private   Vector2              _targetPosition;
                     protected bool                 _pinToTarget = false;
                     private   Transform            _pivot;    
    [SerializeField] private   float                _bowRotateRadius = 0.5f;

    [Inject]
    public void Construct(MousePositionHandler mouse)
    {
        _mousePositionHandler = mouse;
        //_eventBus.Subscribe<RenderRangedWeaponPlayAttackSignal>(PlayAttackClip);
        //_mousePositionHandler = ServiceLocator.Current.Get<MousePositionHandler>();

        //_pivot = ServiceLocator.Current.Get<WeaponSlotController>().GetWeaponSlotTransform();
    }

    private void Start()
    {
        _pivot = ServiceLocator.Current.Get<WeaponSlotController>().GetWeaponSlotTransform();
        InitRenderWeapon();
        _eventBus.Subscribe<RenderRangedWeaponPlayAttackSignal>(PlayAttackClip);
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
        RotateWeaponTo(mouseWorldPos);
    }

    private void PinWeaponToTarget()
    {
        Vector3 direction = (Vector3)_targetPosition;
        RotateWeaponTo(direction);
    }

    private void RotateWeaponTo(Vector2 target)
    {
        Vector2 direction = target - (Vector2)_pivot.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _pivot.rotation = Quaternion.Euler(0f, 0f, angle);

        transform.position = _pivot.position + _pivot.right * _bowRotateRadius;

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
