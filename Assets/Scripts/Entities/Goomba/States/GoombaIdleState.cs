using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaIdleState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly GoombaEntity _goombaEntity;

    public GoombaIdleState(StateMachine stateMachine, GoombaEntity goombaEntity)
    {
        _stateMachine = stateMachine;
        _goombaEntity = goombaEntity;
    }

    public void Tick()
    {

    }

    public void FixedTick()
    {

    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }
}
