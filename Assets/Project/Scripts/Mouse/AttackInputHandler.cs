using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackInputHandler : MonoBehaviour
{
    private IAttackable _attackable;
    private GameInput _gameInput;

    public void Awake()
    {
        _attackable = GetComponentInParent<IAttackable>();
        _gameInput = new GameInput();
        _gameInput.Gameplay.Attack.performed += OnAttack;
        _gameInput.Enable();
    }

    private void OnAttack(InputAction.CallbackContext obj)
    {
        ReadMousePosition();
    }

    private void OnDestroy()
    {
        _gameInput.Dispose();
    }

    private void ReadMousePosition()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane));

        _attackable.AttackEvent(worldPos);
    }
}