using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CharacterMovementInputController : MonoBehaviour
{
    private IMovable _movable;
    private GameInput _gameInput;

    public void Awake()
    {
        _movable = GetComponentInParent<IMovable>();
        _gameInput = new GameInput();
        _gameInput.Enable();
       
    }

    private void Update()
    {
        if (_movable != null) ReadDirection();
        else Debug.Log("IMovable not found in parent objects!");
    }

    private void ReadDirection()
    {
        var direction = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
        var isoDirection = new Vector2(direction.x, direction.y * 0.5f);
        _movable.Move(isoDirection);
    }
}
