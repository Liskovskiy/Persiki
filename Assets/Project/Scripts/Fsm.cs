using System;
using FSM.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fsm
{
    private FsmState StateCurrent { get; set; }

    private Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>

        public void AddState(FsmState state)
    {
        _stetes.Add(state.GetType(), state);
    }

    public void SetState<T>() where : FsmState
    {
        var type = typeof(T);

        if (StateCurren.GetType() == type)
        {
            return
        }

        if (_states.TryGetValue(type, out var newState))
        {
            StateCurrent?.Exit();

            StateCurrent = newState;

            StateCurrent.Enter();

        }
    }

    public void Update
    {
        StateCurrent?.Update
    }
}
