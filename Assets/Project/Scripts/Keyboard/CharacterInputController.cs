using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    private IMovable _movable;
    private GameInput _gameInput;

    public void Awake()
    {
        _movable = GetComponent<IMovable>();
        _gameInput = new GameInput();
        _gameInput.Enable();
       
    }
    public void Initialize()
    {
        //_movable = GetComponent<IMovable>();
        Debug.Log("Keyboard Init");
    }

    private void Update()
    {
        if (_movable != null) ReadMove();
    }

    private void ReadMove()
    {
        var direction = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
        _movable.Move(direction);
    }
}
