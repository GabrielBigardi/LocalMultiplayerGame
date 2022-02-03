using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaWalkState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly GoombaEntity _entity;

    public GoombaWalkState(StateMachine stateMachine, GoombaEntity goombaEntity)
    {
        _stateMachine = stateMachine;
        _entity = goombaEntity;
    }

    public void Tick()
    {

    }

    public void FixedTick()
    {
        Debug.Log("a");
        _entity.core.rgbd.velocity = Vector2.left * 5f * Time.deltaTime;
    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }
}
