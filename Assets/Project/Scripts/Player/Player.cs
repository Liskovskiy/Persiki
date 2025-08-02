using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IMovable, IAttackable
{
    private PlayerMoveFsm       _playerFsm;
    private PlayerAttackFsm     _playerAttackFsm;

    private PlayerMovement      _playerMovement;
    private PlayerAttackManager _playerAttackManager;
    public void Initialize()
    {
        Debug.Log("Player Init");

        _playerMovement = GetComponentInChildren<PlayerMovement>();
        _playerAttackManager = GetComponentInChildren<PlayerAttackManager>();

        _playerMovement.Initialize();
        _playerAttackManager.Initialize();

        _playerFsm = new PlayerMoveFsm(_playerMovement.MoveToDirection);
        _playerAttackFsm = new PlayerAttackFsm(_playerAttackManager.AttackTarget);
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
        Debug.Log($"Target Position: {targetPosition}");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player take damage");
    }
}
