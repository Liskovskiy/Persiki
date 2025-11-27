using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;

public class RenderRangedWeapon : RenderWeapon
{
    [SerializeField] private string AttackStateName;
    protected EventBus _eventBus;
    void Start()
    {
        InitRender();
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _eventBus.Subscribe<RenderRangedWeaponPlayAttackSignal>(PlayAttackClip);
    }

    public void PlayAttackClip(RenderRangedWeaponPlayAttackSignal signal)
    {
        _animator.Play(AttackStateName);
        StartCoroutine(WaitUntilAttackEnds());
    }
    private IEnumerator WaitUntilAttackEnds()
    {
        yield return null;

        while (true)
        {
            AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);

            if (info.IsName(AttackStateName))
            {
                if (info.normalizedTime >= 1f)
                {
                    break;
                }
            }
            else
            {
                break;
            }

            yield return null;
        }
        OnAttackAnimationEnd();
    }

    private void OnAttackAnimationEnd()
    {
        _eventBus.Invoke(new RenderRangedWeaponFinishAttackSignal());
    }
}
