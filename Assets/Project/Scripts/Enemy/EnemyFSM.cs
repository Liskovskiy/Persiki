using System;
using UnityEngine;
using UnityHFSM;

public class EnemyFSM
{
    private StateMachine _enemyFsm;

     public EnemyFSM()
    {
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
        Debug.Log("NoDamge onEnter");
    }

    private void FsmNoDamageState()
    {
        Debug.Log("NoDamge onLogic");
    }

    private void FsmNoDamageStateExit()
    {
        Debug.Log("NoDamge onExit");
    }

    private void FsmGetDamageStateEnter()
    {
        Debug.Log("GetDamage onEnter");
    }

    private void FsmGetDamageState()
    {
        Debug.Log("GetDamage onLogic");
    }

    private void FsmGetDamageStateExit()
    {
        Debug.Log("GetDamage onExit");
    }

    private bool FsmTransitionGuardNoDamageToGetDamage(Transition<string> transition)
    {
        bool isTransitionAllowed = false;
        // if (_enemyCollision.collisionDetected == "Player")
        // {
        //     isTransitionAllowed = true;
        //     Debug.Log("Transition from NoDamage to GetDamage allowed");
        // }
        if(Input.GetKeyDown(KeyCode.E))
        {
            isTransitionAllowed = true;
            Debug.Log("Transition from NoDamage to GetDamage allowed");
        }
        


        return isTransitionAllowed;
    }

    private bool FsmTransitionGuardGetDamageToNoDamage(Transition<string> transition)
    {
        bool isTransitionAllowed = false;

         if(Input.GetKeyDown(KeyCode.Q))
        {
            isTransitionAllowed = true;
            Debug.Log("Transition from NoDamage to GetDamage allowed");
        }

        return isTransitionAllowed;
    }

}
