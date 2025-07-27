// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting.FullSerializer;
// using UnityEngine;
// using UnityHFSM;
// public class FSMtest : MonoBehaviour
// {
//     StateMachine fsm = new StateMachine();

//     void Start()
//     {
//         fsm.SetStartState("Idle");
//         fsm.AddState("Running", onLogic: state => { Debug.Log("Running state"); });
//         fsm.AddState("Idle", onLogic: state => { Debug.Log("Idle state"); });
//         fsm.AddState("Jump", onLogic: state => { Debug.Log("Jump state"); });
//         fsm.AddTransition("Running", "Jump",
//         transition => Input.GetKeyDown(KeyCode.Space));
//         Debug.Log("FSM created with states: Running, Idle, Jump");
//         fsm.AddTransition(new TransitionAfter( "Idle", "Running",2));
//         fsm.AddTransition("Jump","Running", 
//         transition => Input.GetKeyUp(KeyCode.Space));
//         fsm.Init();
//     }
//    void Update()
//     {
//         fsm.OnLogic();
//         if (Input.GetKeyDown(KeyCode.Space))
//         {

//             Debug.Log("Space pressed");
//         }

//     }
// }
