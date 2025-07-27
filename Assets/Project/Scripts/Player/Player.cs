using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IMovable
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private Rigidbody2D _rigidbody;
    public void Initialize()
    {
        Debug.Log("Player Init");
    }

    public void FixedUpdate()
    {
        MoveInternal();
    }

    public void Move(Vector2 direction)
    {
        _direction = direction;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player take damage");
    }

    private void MoveInternal()
    {
        _rigidbody.velocity = _direction * _speed;
    }
}
