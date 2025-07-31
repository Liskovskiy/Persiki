using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void Initialize()
    {
        Debug.Log("Player movement Init");
        _rigidbody = GetComponentInParent<Rigidbody2D>();
    }
    public void SetMoveDirection(Vector2 direction)
    {
        _direction = direction;
    }
    private void MoveInternal()
    {
        _rigidbody.velocity = _direction * _speed;
    }
    private void FixedUpdate()
    {
        if (_rigidbody != null) MoveInternal();
    }
}
