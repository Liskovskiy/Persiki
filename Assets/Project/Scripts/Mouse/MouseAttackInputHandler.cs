using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using CustomEventBus;
using CustomEventBus.Signals;

public class MouseAttackInputHandler : MonoBehaviour
{
    private GameInput _gameInput;
    private EventBus _eventBus;
    private Vector3 _worldPos;

    private void Start()
    {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
    }
    public void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Gameplay.Attack.performed += OnAttack;
        _gameInput.Enable();
    }

    private void OnAttack(InputAction.CallbackContext obj)
    {
        ReadMousePosition();
        _eventBus.Invoke(new MouseAttackInputSignal(_worldPos));
    }

    private void OnDestroy()
    {
        _gameInput.Dispose();
    }

    private void ReadMousePosition()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        _worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane));
    }
}