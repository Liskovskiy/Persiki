using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;
using Zenject;
public class Player : MonoBehaviour, IDamageable, IMovable, IService
{
    private PlayerMoveFsm       _playerFsm;
    private PlayerAttackFsm     _playerAttackFsm;
    private PlayerMovement      _playerMovement;
    private EventBus            _eventBus;

    [Inject]
    public void Init(EventBus eventBus)
    {
        _eventBus = eventBus;
        Debug.Log("Player Init");
        _playerMovement = GetComponentInChildren<PlayerMovement>();

        _playerMovement.Initialize();

        _playerFsm = new PlayerMoveFsm(_playerMovement.MoveToDirection);
        _playerAttackFsm = new PlayerAttackFsm(_eventBus);

        //_eventBus = ServiceLocator.Current.Get<EventBus>();

        _eventBus.Subscribe<MouseAttackInputSignal>(AttackEventHandler);
    }
    public void Initialize()
    {
        
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
    public void AttackEventHandler(MouseAttackInputSignal signal)
    {
        _playerAttackFsm.TargetPositionUpdate(signal.worldPos);
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
