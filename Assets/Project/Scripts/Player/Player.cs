using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IMovable
{
    private PlayerMovement _playerMovement;
    public void Initialize()
    {
        Debug.Log("Player Init");
        ComponentInit();
    }

    private void ComponentInit()
    {
        /* PlayerMovement component start init */

        _playerMovement = GetComponentInChildren<PlayerMovement>();
        if (_playerMovement != null) _playerMovement.Initialize();
        else Debug.Log("Missing PlayerMovement!");

        /* PlayerMovement component end init */
    }

    public void Move(Vector2 direction)
    {
        if (_playerMovement != null) _playerMovement.SetMoveDirection(direction);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player take damage");
    }
}
