using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IMovable, IAttackable , IService
{
    private PlayerMoveFsm       _playerFsm;
    private PlayerAttackFsm     _playerAttackFsm;
    private PlayerMovement      _playerMovement;
    public void Initialize()
    {
        Debug.Log("Player Init");
        _playerMovement = GetComponentInChildren<PlayerMovement>();

        _playerMovement.Initialize();

        _playerFsm = new PlayerMoveFsm(_playerMovement.MoveToDirection);
        _playerAttackFsm = new PlayerAttackFsm();
    }

    private void Update()
    {
        _playerFsm.FsmRun();
        _playerAttackFsm.FsmRun();
    }

    public void MoveEvent(Vector2 direction)
    {
        _playerFsm.PlayerDirectionUpdate(direction);
    }

    public void AttackEvent(Vector2 targetPosition)
    {
        _playerAttackFsm.TargetPositionUpdate(targetPosition);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player take damage");
    }

    public Vector2 GetPlayerPosition()
    {
        return (Vector2)gameObject.transform.position;
    }
}
