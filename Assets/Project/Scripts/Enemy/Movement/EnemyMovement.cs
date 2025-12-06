using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 20f;
    private Rigidbody2D _rb;
    [SerializeField] private Player _player; // temp!
    public void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_player = ServiceLocator.Current.Get<Player>();
    }

    public void Knockback()
    {
        Vector2 direction = ((Vector2)transform.position - _player.GetPlayerPosition()).normalized;
        _rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }
}
