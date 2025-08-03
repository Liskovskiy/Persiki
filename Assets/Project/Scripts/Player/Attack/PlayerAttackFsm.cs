using System;
using System.Collections;
using System.Collections.Generic;
using UnityHFSM;
using UnityEngine;

public class PlayerAttackFsm
{
    private readonly StateMachine _fsm;
    private PlayerAttackData _playerAttackFsmData;

    public PlayerAttackFsm()
    {

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

        AttackManager.Instance.OnAttackResponse += AttackFinished;

        _fsm.Init();
    }

    public void FsmRun()
    {
        _fsm.OnLogic();
    }

    public void AttackFinished()
    {
        _playerAttackFsmData.AttackStatus = EAttackStatus.Finished;
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
        AttackManager.Instance.AttackRequest(_playerAttackFsmData.TargetPosition);
    }
    private void FsmAttackState()
    {
        Debug.Log("Attack onLogic");
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
