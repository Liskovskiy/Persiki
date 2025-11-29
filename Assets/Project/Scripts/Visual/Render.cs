using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Render : MonoBehaviour
{
    protected Animator  _animator;
    private   Coroutine _currentRoutine;
    protected void InitRender()
    {
        _animator = GetComponent<Animator>();
    }

    protected void PlayAnimationClip(AnimationClip _animationClip, System.Action _onAnimationFinished = null, bool hasExitTime = true, int _layer = 0)
    {
        if (_currentRoutine != null && hasExitTime) return;
        _animator.Play(_animationClip.name, _layer);
        _currentRoutine = StartCoroutine(WaitForAnimationEnd(_animationClip, _onAnimationFinished));
    }

    private IEnumerator WaitForAnimationEnd(AnimationClip clip, System.Action onEnd)
    {
        float realTime = clip.length;

        yield return new WaitForSeconds(realTime);

        onEnd?.Invoke();

        _currentRoutine = null;
    }
}
