using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IMovable
{
    private PlayerFsm _playerFsm;
    private PlayerMovement _playerMovement;
    public void Initialize()
    {
        Debug.Log("Player Init");
        _playerMovement = GetComponentInChildren<PlayerMovement>();
        _playerMovement.Initialize();


        _playerFsm = new PlayerFsm(_playerMovement.MoveToDirection);
    }

    private void Update()
    {
        _playerFsm.FsmRun();
    }

    public void MoveEvent(Vector2 direction)
    {
        _playerFsm.PlayerDirectionUpdate(direction);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player take damage");
    }
}
