using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityHFSM;

public class PlayerFsm : MonoBehaviour
{
    StateMachine fsm = new StateMachine();
    int HP = 100;
    void Start()
    {
       

        fsm.SetStartState("Idle");
        fsm.AddState("Idle", onLogic: state => { Debug.Log("Idle state"); });
        fsm.AddState("Walk", onLogic: state => { Debug.Log("Walk state"); });
        fsm.AddState("Attack", onLogic: state => { Debug.Log("Attack state"); });
        fsm.AddState("GetDamage", onLogic: state => { Debug.Log("GetDamage state"); });
        fsm.AddState("Death", onLogic: state => { Debug.Log("Death state"); });


        fsm.AddTransition("Idle", "Walk",
            transition => Input.GetKeyDown(KeyCode.W));
        fsm.AddTransition("Walk", "Idle",
            transition => Input.GetKeyUp(KeyCode.W));

        fsm.AddTransition("Idle", "Attack",
            transition => Input.GetMouseButtonDown(0));
        fsm.AddTransition("Attack", "Idle",
            transition => !Input.anyKey);

        fsm.AddTransition("Idle", "GetDamage",
            transition => ShoodTakeDamage());
        fsm.AddTransition("GetDamage", "Death",
            transition => Die());
        fsm.AddTransition("GetDamage", "Idle",
            transition => !ShoodTakeDamage());

        fsm.AddTransition("Walk", "GetDamage",
            transition => ShoodTakeDamage());
        fsm.AddTransition("GetDamage","Walk", 
            transition => Input.GetKeyDown(KeyCode.W));

        fsm.AddTransition("Walk", "Attack",
            transition => Input.GetMouseButtonDown(0));
        fsm.AddTransition("Attack","Walk",
            transition => Input.GetKey(KeyCode.W)); 

        fsm.AddTransition("Attack", "GetDamage",
            transition => ShoodTakeDamage());
        fsm.AddTransition("GetDamage","Attack", 
            transition => !ShoodTakeDamage() && Input.GetMouseButton(0));
        
        fsm.Init();
    }
    void Update()
    {
        fsm.OnLogic();
    }

    bool ShoodTakeDamage()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Player took damage");
            HP -= 50;
            return true;
        }
        else return false;
    }
    
    bool Die()
    {
        if (HP <= 0)
        {
            Debug.Log("Player died");
            return true;
        }
        else return false;
    }
}
