using System;
using System.Collections;
using System.Collections.Generic;
using UnityHFSM;
using UnityEngine;

public class PlayerAttackFsm
{
    private StateMachine _fsm;
    private PlayerAttackData _playerAttackFsmData;
    private Action<Vector2> OnAttackRequest;

    public PlayerAttackFsm(Action<Vector2> Attack)
    {
        OnAttackRequest = Attack;

        _fsm = new StateMachine();

        _fsm.SetStartState("Passive");

        _fsm.AddState("Passive",
            onEnter: state => FsmPassiveStateEnter(),
            onLogic: state => FsmPassiveState(),
            onExit:  state => FsmPassiveStateExit());

        _fsm.AddState("Attack",
            onEnter: state => FsmAttackStateEnter(),
            onLogic: state => FsmAttackState(),
            onExit:  state => FsmAttackStateExit());

        _fsm.AddTransition("Passive", "Attack", FsmTransitionGuardPassiveToAttack);
        _fsm.AddTransition("Attack", "Passive", FsmTransitionGuardAttackToPassive);

        _fsm.Init();
    }

    public void FsmRun()
    {
        _fsm.OnLogic();
    }

    public void TargetPositionUpdate(Vector2 newTargetPosition)
    {
        _playerAttackFsmData.TargetPosition = newTargetPosition;
        _playerAttackFsmData.HasTarget = true;
    }

    private void FsmPassiveStateEnter()
    {
        Debug.Log("Passive onEnter");
    }
    private void FsmPassiveState()
    {
        Debug.Log("Passive onLogic");
    }
    private void FsmPassiveStateExit()
    {
        Debug.Log("Passive onExit");
    }
    private void FsmAttackStateEnter()
    {
        Debug.Log("Attack onEnter");
        _playerAttackFsmData.AttackStatus = EAttackStatus.InProgress;
        OnAttackRequest(_playerAttackFsmData.TargetPosition);
    }
    private void FsmAttackState()
    {
        Debug.Log("Attack onLogic");
        _playerAttackFsmData.AttackStatus = EAttackStatus.Finished;
    }
    private void FsmAttackStateExit()
    {
        _playerAttackFsmData.HasTarget = false;
        Debug.Log("Attack onExit");
    }

    private bool FsmTransitionGuardPassiveToAttack(Transition<string> transition)
    {
        bool isTransitionAllowed = false;
        if(_playerAttackFsmData.HasTarget) isTransitionAllowed = true;
        return isTransitionAllowed;
    }

    private bool FsmTransitionGuardAttackToPassive(Transition<string> transition)
    {
        bool isTransitionAllowed = false;
        if (_playerAttackFsmData.AttackStatus == EAttackStatus.Finished) isTransitionAllowed = true;
        return isTransitionAllowed;
    }


}
