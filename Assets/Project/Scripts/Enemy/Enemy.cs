using CustomEventBus;
using CustomEventBus.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private Color _hitColor = Color.red;
    [SerializeField] private float _flashTime = 0.1f;
    private SpriteRenderer _spriteRenderer;
    private EnemyFSM _enemyFsm;
    private EventBus _eventBus;
    private Color _defaultColor;

    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _eventBus.Subscribe<EnemyDamagedSignal>(OnEnemyGetDamage);
        _enemyFsm = new EnemyFSM();
        _defaultColor = _spriteRenderer.color;
    }
    private void Update()
    {
        _enemyFsm.FsmRun();

    }

    private void OnEnemyGetDamage(EnemyDamagedSignal signal)
    {
        if (signal.Enemy != this) return;
        if (_health > 0) _health -= signal.Health;
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        _spriteRenderer.color = _hitColor;
        yield return new WaitForSeconds(_flashTime);
        _spriteRenderer.color = _defaultColor;
    }
}
