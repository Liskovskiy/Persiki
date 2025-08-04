#define DEBUG_MODE
using System;
using UnityEngine;
using UnityHFSM;

public class EnemyDamageFSM
{
    private StateMachine _enemyFsm;
    private EnemyCollision _enemyCollision;

     public EnemyDamageFSM(EnemyCollision enemyCollision)
    {
        _enemyCollision = enemyCollision;
        _enemyFsm = new StateMachine();

        _enemyFsm.SetStartState("NoDamage");

        _enemyFsm.AddState("NoDamage",
            onEnter: state => FsmNoDamageStateEnter(),
            onLogic: state => FsmNoDamageState(),
            onExit: state => FsmNoDamageStateExit());

        _enemyFsm.AddState("GetDamage",
            onEnter: state => FsmGetDamageStateEnter(),
            onLogic: state => FsmGetDamageState(),
            onExit: state => FsmGetDamageStateExit());

        _enemyFsm.AddTransition("NoDamage", "GetDamage", FsmTransitionGuardNoDamageToGetDamage);
        _enemyFsm.AddTransition("GetDamage", "NoDamage", FsmTransitionGuardGetDamageToNoDamage);

        _enemyFsm.Init();
    }

    public void FsmRun()
    {
        _enemyFsm.OnLogic();
    }


    private void FsmNoDamageStateEnter()
    {
#if DEBUG_MODE
        Debug.Log("NoDamge onEnter");
#endif
    }

    private void FsmNoDamageState()
    {
#if DEBUG_MODE
        Debug.Log("NoDamge onLogic");
#endif
    }

    private void FsmNoDamageStateExit()
    {
#if DEBUG_MODE
        Debug.Log("NoDamge onExit");
#endif
    }

    private void FsmGetDamageStateEnter()
    {
#if DEBUG_MODE
        Debug.Log("GetDamage onEnter");
#endif
    }

    private void FsmGetDamageState()
    {
#if DEBUG_MODE
        Debug.Log("GetDamage onLogic");
#endif
    }

    private void FsmGetDamageStateExit()
    {
#if DEBUG_MODE
        Debug.Log("GetDamage onExit");
#endif
    }
    


    private bool FsmTransitionGuardNoDamageToGetDamage(Transition<string> transition)
    {
        return _enemyCollision.isTransitionAllowed;
    }

    private bool FsmTransitionGuardGetDamageToNoDamage(Transition<string> transition)
    {
        bool isTransitionAllowed = !_enemyCollision.isTransitionAllowed;
        return isTransitionAllowed;
    }

}
